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
	/// This object represents the properties and methods of a ZhuangXiu_XunJian.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ZhuangXiu_XunJian 
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
		private int _zhuangXiuID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ZhuangXiuID
		{
			[DebuggerStepThrough()]
			get { return this._zhuangXiuID; }
			set 
			{
				if (this._zhuangXiuID != value) 
				{
					this._zhuangXiuID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ZhuangXiuID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _xunJianTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime XunJianTime
		{
			[DebuggerStepThrough()]
			get { return this._xunJianTime; }
			set 
			{
				if (this._xunJianTime != value) 
				{
					this._xunJianTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("XunJianTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _xunJianMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string XunJianMan
		{
			[DebuggerStepThrough()]
			get { return this._xunJianMan; }
			set 
			{
				if (this._xunJianMan != value) 
				{
					this._xunJianMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("XunJianMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _xunJianStatus = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string XunJianStatus
		{
			[DebuggerStepThrough()]
			get { return this._xunJianStatus; }
			set 
			{
				if (this._xunJianStatus != value) 
				{
					this._xunJianStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("XunJianStatus");
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
		private string _weiGuiProject = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WeiGuiProject
		{
			[DebuggerStepThrough()]
			get { return this._weiGuiProject; }
			set 
			{
				if (this._weiGuiProject != value) 
				{
					this._weiGuiProject = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiGuiProject");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _weiGuiCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal WeiGuiCost
		{
			[DebuggerStepThrough()]
			get { return this._weiGuiCost; }
			set 
			{
				if (this._weiGuiCost != value) 
				{
					this._weiGuiCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiGuiCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _weiGuiRuleID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WeiGuiRuleID
		{
			[DebuggerStepThrough()]
			get { return this._weiGuiRuleID; }
			set 
			{
				if (this._weiGuiRuleID != value) 
				{
					this._weiGuiRuleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiGuiRuleID");
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
	[ZhuangXiuID] int,
	[XunJianTime] datetime,
	[XunJianMan] nvarchar(50),
	[XunJianStatus] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[WeiGuiProject] nvarchar(200),
	[WeiGuiCost] decimal(18, 2),
	[WeiGuiRuleID] nvarchar(200)
);

INSERT INTO [dbo].[ZhuangXiu_XunJian] (
	[ZhuangXiu_XunJian].[ZhuangXiuID],
	[ZhuangXiu_XunJian].[XunJianTime],
	[ZhuangXiu_XunJian].[XunJianMan],
	[ZhuangXiu_XunJian].[XunJianStatus],
	[ZhuangXiu_XunJian].[Remark],
	[ZhuangXiu_XunJian].[AddTime],
	[ZhuangXiu_XunJian].[AddMan],
	[ZhuangXiu_XunJian].[WeiGuiProject],
	[ZhuangXiu_XunJian].[WeiGuiCost],
	[ZhuangXiu_XunJian].[WeiGuiRuleID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ZhuangXiuID],
	INSERTED.[XunJianTime],
	INSERTED.[XunJianMan],
	INSERTED.[XunJianStatus],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[WeiGuiProject],
	INSERTED.[WeiGuiCost],
	INSERTED.[WeiGuiRuleID]
into @table
VALUES ( 
	@ZhuangXiuID,
	@XunJianTime,
	@XunJianMan,
	@XunJianStatus,
	@Remark,
	@AddTime,
	@AddMan,
	@WeiGuiProject,
	@WeiGuiCost,
	@WeiGuiRuleID 
); 

SELECT 
	[ID],
	[ZhuangXiuID],
	[XunJianTime],
	[XunJianMan],
	[XunJianStatus],
	[Remark],
	[AddTime],
	[AddMan],
	[WeiGuiProject],
	[WeiGuiCost],
	[WeiGuiRuleID] 
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
	[ZhuangXiuID] int,
	[XunJianTime] datetime,
	[XunJianMan] nvarchar(50),
	[XunJianStatus] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[WeiGuiProject] nvarchar(200),
	[WeiGuiCost] decimal(18, 2),
	[WeiGuiRuleID] nvarchar(200)
);

UPDATE [dbo].[ZhuangXiu_XunJian] SET 
	[ZhuangXiu_XunJian].[ZhuangXiuID] = @ZhuangXiuID,
	[ZhuangXiu_XunJian].[XunJianTime] = @XunJianTime,
	[ZhuangXiu_XunJian].[XunJianMan] = @XunJianMan,
	[ZhuangXiu_XunJian].[XunJianStatus] = @XunJianStatus,
	[ZhuangXiu_XunJian].[Remark] = @Remark,
	[ZhuangXiu_XunJian].[AddTime] = @AddTime,
	[ZhuangXiu_XunJian].[AddMan] = @AddMan,
	[ZhuangXiu_XunJian].[WeiGuiProject] = @WeiGuiProject,
	[ZhuangXiu_XunJian].[WeiGuiCost] = @WeiGuiCost,
	[ZhuangXiu_XunJian].[WeiGuiRuleID] = @WeiGuiRuleID 
output 
	INSERTED.[ID],
	INSERTED.[ZhuangXiuID],
	INSERTED.[XunJianTime],
	INSERTED.[XunJianMan],
	INSERTED.[XunJianStatus],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[WeiGuiProject],
	INSERTED.[WeiGuiCost],
	INSERTED.[WeiGuiRuleID]
into @table
WHERE 
	[ZhuangXiu_XunJian].[ID] = @ID

SELECT 
	[ID],
	[ZhuangXiuID],
	[XunJianTime],
	[XunJianMan],
	[XunJianStatus],
	[Remark],
	[AddTime],
	[AddMan],
	[WeiGuiProject],
	[WeiGuiCost],
	[WeiGuiRuleID] 
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
DELETE FROM [dbo].[ZhuangXiu_XunJian]
WHERE 
	[ZhuangXiu_XunJian].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ZhuangXiu_XunJian() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetZhuangXiu_XunJian(this.ID));
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
	[ZhuangXiu_XunJian].[ID],
	[ZhuangXiu_XunJian].[ZhuangXiuID],
	[ZhuangXiu_XunJian].[XunJianTime],
	[ZhuangXiu_XunJian].[XunJianMan],
	[ZhuangXiu_XunJian].[XunJianStatus],
	[ZhuangXiu_XunJian].[Remark],
	[ZhuangXiu_XunJian].[AddTime],
	[ZhuangXiu_XunJian].[AddMan],
	[ZhuangXiu_XunJian].[WeiGuiProject],
	[ZhuangXiu_XunJian].[WeiGuiCost],
	[ZhuangXiu_XunJian].[WeiGuiRuleID]
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
                return "ZhuangXiu_XunJian";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ZhuangXiu_XunJian into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="zhuangXiuID">zhuangXiuID</param>
		/// <param name="xunJianTime">xunJianTime</param>
		/// <param name="xunJianMan">xunJianMan</param>
		/// <param name="xunJianStatus">xunJianStatus</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="weiGuiProject">weiGuiProject</param>
		/// <param name="weiGuiCost">weiGuiCost</param>
		/// <param name="weiGuiRuleID">weiGuiRuleID</param>
		public static void InsertZhuangXiu_XunJian(int @zhuangXiuID, DateTime @xunJianTime, string @xunJianMan, string @xunJianStatus, string @remark, DateTime @addTime, string @addMan, string @weiGuiProject, decimal @weiGuiCost, string @weiGuiRuleID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertZhuangXiu_XunJian(@zhuangXiuID, @xunJianTime, @xunJianMan, @xunJianStatus, @remark, @addTime, @addMan, @weiGuiProject, @weiGuiCost, @weiGuiRuleID, helper);
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
		/// Insert a ZhuangXiu_XunJian into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="zhuangXiuID">zhuangXiuID</param>
		/// <param name="xunJianTime">xunJianTime</param>
		/// <param name="xunJianMan">xunJianMan</param>
		/// <param name="xunJianStatus">xunJianStatus</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="weiGuiProject">weiGuiProject</param>
		/// <param name="weiGuiCost">weiGuiCost</param>
		/// <param name="weiGuiRuleID">weiGuiRuleID</param>
		/// <param name="helper">helper</param>
		internal static void InsertZhuangXiu_XunJian(int @zhuangXiuID, DateTime @xunJianTime, string @xunJianMan, string @xunJianStatus, string @remark, DateTime @addTime, string @addMan, string @weiGuiProject, decimal @weiGuiCost, string @weiGuiRuleID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ZhuangXiuID] int,
	[XunJianTime] datetime,
	[XunJianMan] nvarchar(50),
	[XunJianStatus] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[WeiGuiProject] nvarchar(200),
	[WeiGuiCost] decimal(18, 2),
	[WeiGuiRuleID] nvarchar(200)
);

INSERT INTO [dbo].[ZhuangXiu_XunJian] (
	[ZhuangXiu_XunJian].[ZhuangXiuID],
	[ZhuangXiu_XunJian].[XunJianTime],
	[ZhuangXiu_XunJian].[XunJianMan],
	[ZhuangXiu_XunJian].[XunJianStatus],
	[ZhuangXiu_XunJian].[Remark],
	[ZhuangXiu_XunJian].[AddTime],
	[ZhuangXiu_XunJian].[AddMan],
	[ZhuangXiu_XunJian].[WeiGuiProject],
	[ZhuangXiu_XunJian].[WeiGuiCost],
	[ZhuangXiu_XunJian].[WeiGuiRuleID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ZhuangXiuID],
	INSERTED.[XunJianTime],
	INSERTED.[XunJianMan],
	INSERTED.[XunJianStatus],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[WeiGuiProject],
	INSERTED.[WeiGuiCost],
	INSERTED.[WeiGuiRuleID]
into @table
VALUES ( 
	@ZhuangXiuID,
	@XunJianTime,
	@XunJianMan,
	@XunJianStatus,
	@Remark,
	@AddTime,
	@AddMan,
	@WeiGuiProject,
	@WeiGuiCost,
	@WeiGuiRuleID 
); 

SELECT 
	[ID],
	[ZhuangXiuID],
	[XunJianTime],
	[XunJianMan],
	[XunJianStatus],
	[Remark],
	[AddTime],
	[AddMan],
	[WeiGuiProject],
	[WeiGuiCost],
	[WeiGuiRuleID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ZhuangXiuID", EntityBase.GetDatabaseValue(@zhuangXiuID)));
			parameters.Add(new SqlParameter("@XunJianTime", EntityBase.GetDatabaseValue(@xunJianTime)));
			parameters.Add(new SqlParameter("@XunJianMan", EntityBase.GetDatabaseValue(@xunJianMan)));
			parameters.Add(new SqlParameter("@XunJianStatus", EntityBase.GetDatabaseValue(@xunJianStatus)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@WeiGuiProject", EntityBase.GetDatabaseValue(@weiGuiProject)));
			parameters.Add(new SqlParameter("@WeiGuiCost", EntityBase.GetDatabaseValue(@weiGuiCost)));
			parameters.Add(new SqlParameter("@WeiGuiRuleID", EntityBase.GetDatabaseValue(@weiGuiRuleID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ZhuangXiu_XunJian into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="zhuangXiuID">zhuangXiuID</param>
		/// <param name="xunJianTime">xunJianTime</param>
		/// <param name="xunJianMan">xunJianMan</param>
		/// <param name="xunJianStatus">xunJianStatus</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="weiGuiProject">weiGuiProject</param>
		/// <param name="weiGuiCost">weiGuiCost</param>
		/// <param name="weiGuiRuleID">weiGuiRuleID</param>
		public static void UpdateZhuangXiu_XunJian(int @iD, int @zhuangXiuID, DateTime @xunJianTime, string @xunJianMan, string @xunJianStatus, string @remark, DateTime @addTime, string @addMan, string @weiGuiProject, decimal @weiGuiCost, string @weiGuiRuleID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateZhuangXiu_XunJian(@iD, @zhuangXiuID, @xunJianTime, @xunJianMan, @xunJianStatus, @remark, @addTime, @addMan, @weiGuiProject, @weiGuiCost, @weiGuiRuleID, helper);
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
		/// Updates a ZhuangXiu_XunJian into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="zhuangXiuID">zhuangXiuID</param>
		/// <param name="xunJianTime">xunJianTime</param>
		/// <param name="xunJianMan">xunJianMan</param>
		/// <param name="xunJianStatus">xunJianStatus</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="weiGuiProject">weiGuiProject</param>
		/// <param name="weiGuiCost">weiGuiCost</param>
		/// <param name="weiGuiRuleID">weiGuiRuleID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateZhuangXiu_XunJian(int @iD, int @zhuangXiuID, DateTime @xunJianTime, string @xunJianMan, string @xunJianStatus, string @remark, DateTime @addTime, string @addMan, string @weiGuiProject, decimal @weiGuiCost, string @weiGuiRuleID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ZhuangXiuID] int,
	[XunJianTime] datetime,
	[XunJianMan] nvarchar(50),
	[XunJianStatus] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[WeiGuiProject] nvarchar(200),
	[WeiGuiCost] decimal(18, 2),
	[WeiGuiRuleID] nvarchar(200)
);

UPDATE [dbo].[ZhuangXiu_XunJian] SET 
	[ZhuangXiu_XunJian].[ZhuangXiuID] = @ZhuangXiuID,
	[ZhuangXiu_XunJian].[XunJianTime] = @XunJianTime,
	[ZhuangXiu_XunJian].[XunJianMan] = @XunJianMan,
	[ZhuangXiu_XunJian].[XunJianStatus] = @XunJianStatus,
	[ZhuangXiu_XunJian].[Remark] = @Remark,
	[ZhuangXiu_XunJian].[AddTime] = @AddTime,
	[ZhuangXiu_XunJian].[AddMan] = @AddMan,
	[ZhuangXiu_XunJian].[WeiGuiProject] = @WeiGuiProject,
	[ZhuangXiu_XunJian].[WeiGuiCost] = @WeiGuiCost,
	[ZhuangXiu_XunJian].[WeiGuiRuleID] = @WeiGuiRuleID 
output 
	INSERTED.[ID],
	INSERTED.[ZhuangXiuID],
	INSERTED.[XunJianTime],
	INSERTED.[XunJianMan],
	INSERTED.[XunJianStatus],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[WeiGuiProject],
	INSERTED.[WeiGuiCost],
	INSERTED.[WeiGuiRuleID]
into @table
WHERE 
	[ZhuangXiu_XunJian].[ID] = @ID

SELECT 
	[ID],
	[ZhuangXiuID],
	[XunJianTime],
	[XunJianMan],
	[XunJianStatus],
	[Remark],
	[AddTime],
	[AddMan],
	[WeiGuiProject],
	[WeiGuiCost],
	[WeiGuiRuleID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ZhuangXiuID", EntityBase.GetDatabaseValue(@zhuangXiuID)));
			parameters.Add(new SqlParameter("@XunJianTime", EntityBase.GetDatabaseValue(@xunJianTime)));
			parameters.Add(new SqlParameter("@XunJianMan", EntityBase.GetDatabaseValue(@xunJianMan)));
			parameters.Add(new SqlParameter("@XunJianStatus", EntityBase.GetDatabaseValue(@xunJianStatus)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@WeiGuiProject", EntityBase.GetDatabaseValue(@weiGuiProject)));
			parameters.Add(new SqlParameter("@WeiGuiCost", EntityBase.GetDatabaseValue(@weiGuiCost)));
			parameters.Add(new SqlParameter("@WeiGuiRuleID", EntityBase.GetDatabaseValue(@weiGuiRuleID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ZhuangXiu_XunJian from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteZhuangXiu_XunJian(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteZhuangXiu_XunJian(@iD, helper);
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
		/// Deletes a ZhuangXiu_XunJian from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteZhuangXiu_XunJian(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ZhuangXiu_XunJian]
WHERE 
	[ZhuangXiu_XunJian].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ZhuangXiu_XunJian object.
		/// </summary>
		/// <returns>The newly created ZhuangXiu_XunJian object.</returns>
		public static ZhuangXiu_XunJian CreateZhuangXiu_XunJian()
		{
			return InitializeNew<ZhuangXiu_XunJian>();
		}
		
		/// <summary>
		/// Retrieve information for a ZhuangXiu_XunJian by a ZhuangXiu_XunJian's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ZhuangXiu_XunJian</returns>
		public static ZhuangXiu_XunJian GetZhuangXiu_XunJian(int @iD)
		{
			string commandText = @"
SELECT 
" + ZhuangXiu_XunJian.SelectFieldList + @"
FROM [dbo].[ZhuangXiu_XunJian] 
WHERE 
	[ZhuangXiu_XunJian].[ID] = @ID " + ZhuangXiu_XunJian.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ZhuangXiu_XunJian>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ZhuangXiu_XunJian by a ZhuangXiu_XunJian's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ZhuangXiu_XunJian</returns>
		public static ZhuangXiu_XunJian GetZhuangXiu_XunJian(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ZhuangXiu_XunJian.SelectFieldList + @"
FROM [dbo].[ZhuangXiu_XunJian] 
WHERE 
	[ZhuangXiu_XunJian].[ID] = @ID " + ZhuangXiu_XunJian.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ZhuangXiu_XunJian>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_XunJian objects.
		/// </summary>
		/// <returns>The retrieved collection of ZhuangXiu_XunJian objects.</returns>
		public static EntityList<ZhuangXiu_XunJian> GetZhuangXiu_XunJians()
		{
			string commandText = @"
SELECT " + ZhuangXiu_XunJian.SelectFieldList + "FROM [dbo].[ZhuangXiu_XunJian] " + ZhuangXiu_XunJian.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ZhuangXiu_XunJian>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ZhuangXiu_XunJian objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ZhuangXiu_XunJian objects.</returns>
        public static EntityList<ZhuangXiu_XunJian> GetZhuangXiu_XunJians(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_XunJian>(SelectFieldList, "FROM [dbo].[ZhuangXiu_XunJian]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ZhuangXiu_XunJian objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ZhuangXiu_XunJian objects.</returns>
        public static EntityList<ZhuangXiu_XunJian> GetZhuangXiu_XunJians(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_XunJian>(SelectFieldList, "FROM [dbo].[ZhuangXiu_XunJian]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ZhuangXiu_XunJian objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ZhuangXiu_XunJian objects.</returns>
		protected static EntityList<ZhuangXiu_XunJian> GetZhuangXiu_XunJians(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_XunJians(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_XunJian objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_XunJian objects.</returns>
		protected static EntityList<ZhuangXiu_XunJian> GetZhuangXiu_XunJians(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_XunJians(string.Empty, where, parameters, ZhuangXiu_XunJian.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_XunJian objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_XunJian objects.</returns>
		protected static EntityList<ZhuangXiu_XunJian> GetZhuangXiu_XunJians(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_XunJians(prefix, where, parameters, ZhuangXiu_XunJian.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_XunJian objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_XunJian objects.</returns>
		protected static EntityList<ZhuangXiu_XunJian> GetZhuangXiu_XunJians(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetZhuangXiu_XunJians(string.Empty, where, parameters, ZhuangXiu_XunJian.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_XunJian objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_XunJian objects.</returns>
		protected static EntityList<ZhuangXiu_XunJian> GetZhuangXiu_XunJians(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetZhuangXiu_XunJians(prefix, where, parameters, ZhuangXiu_XunJian.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_XunJian objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ZhuangXiu_XunJian objects.</returns>
		protected static EntityList<ZhuangXiu_XunJian> GetZhuangXiu_XunJians(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ZhuangXiu_XunJian.SelectFieldList + "FROM [dbo].[ZhuangXiu_XunJian] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ZhuangXiu_XunJian>(reader);
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
        protected static EntityList<ZhuangXiu_XunJian> GetZhuangXiu_XunJians(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_XunJian>(SelectFieldList, "FROM [dbo].[ZhuangXiu_XunJian] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ZhuangXiu_XunJian objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetZhuangXiu_XunJianCount()
        {
            return GetZhuangXiu_XunJianCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ZhuangXiu_XunJian objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetZhuangXiu_XunJianCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ZhuangXiu_XunJian] " + where;

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
		public static partial class ZhuangXiu_XunJian_Properties
		{
			public const string ID = "ID";
			public const string ZhuangXiuID = "ZhuangXiuID";
			public const string XunJianTime = "XunJianTime";
			public const string XunJianMan = "XunJianMan";
			public const string XunJianStatus = "XunJianStatus";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string WeiGuiProject = "WeiGuiProject";
			public const string WeiGuiCost = "WeiGuiCost";
			public const string WeiGuiRuleID = "WeiGuiRuleID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ZhuangXiuID" , "int:"},
    			 {"XunJianTime" , "DateTime:"},
    			 {"XunJianMan" , "string:"},
    			 {"XunJianStatus" , "string:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"WeiGuiProject" , "string:"},
    			 {"WeiGuiCost" , "decimal:"},
    			 {"WeiGuiRuleID" , "string:"},
            };
		}
		#endregion
	}
}
