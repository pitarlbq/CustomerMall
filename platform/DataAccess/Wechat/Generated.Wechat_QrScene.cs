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
	/// This object represents the properties and methods of a Wechat_QrScene.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_QrScene 
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
		private DateTime _creationTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime CreationTime
		{
			[DebuggerStepThrough()]
			get { return this._creationTime; }
			set 
			{
				if (this._creationTime != value) 
				{
					this._creationTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CreationTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _expiredTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ExpiredTime
		{
			[DebuggerStepThrough()]
			get { return this._expiredTime; }
			set 
			{
				if (this._expiredTime != value) 
				{
					this._expiredTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ExpiredTime");
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
		private string _ticket = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Ticket
		{
			[DebuggerStepThrough()]
			get { return this._ticket; }
			set 
			{
				if (this._ticket != value) 
				{
					this._ticket = value;
					this.IsDirty = true;	
					OnPropertyChanged("Ticket");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _scanUrl = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ScanUrl
		{
			[DebuggerStepThrough()]
			get { return this._scanUrl; }
			set 
			{
				if (this._scanUrl != value) 
				{
					this._scanUrl = value;
					this.IsDirty = true;	
					OnPropertyChanged("ScanUrl");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _picUrl = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PicUrl
		{
			[DebuggerStepThrough()]
			get { return this._picUrl; }
			set 
			{
				if (this._picUrl != value) 
				{
					this._picUrl = value;
					this.IsDirty = true;	
					OnPropertyChanged("PicUrl");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _squarePicUrl = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SquarePicUrl
		{
			[DebuggerStepThrough()]
			get { return this._squarePicUrl; }
			set 
			{
				if (this._squarePicUrl != value) 
				{
					this._squarePicUrl = value;
					this.IsDirty = true;	
					OnPropertyChanged("SquarePicUrl");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _teamID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TeamID
		{
			[DebuggerStepThrough()]
			get { return this._teamID; }
			set 
			{
				if (this._teamID != value) 
				{
					this._teamID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TeamID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _qrName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string QrName
		{
			[DebuggerStepThrough()]
			get { return this._qrName; }
			set 
			{
				if (this._qrName != value) 
				{
					this._qrName = value;
					this.IsDirty = true;	
					OnPropertyChanged("QrName");
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
		private string _qrType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string QrType
		{
			[DebuggerStepThrough()]
			get { return this._qrType; }
			set 
			{
				if (this._qrType != value) 
				{
					this._qrType = value;
					this.IsDirty = true;	
					OnPropertyChanged("QrType");
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
		[DataObjectField(false, false, true)]
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
	[CreationTime] datetime,
	[ExpiredTime] datetime,
	[OpenID] nvarchar(500),
	[Ticket] nvarchar(500),
	[ScanUrl] nvarchar(500),
	[PicUrl] nvarchar(500),
	[SquarePicUrl] nvarchar(500),
	[TeamID] int,
	[QrName] nvarchar(50),
	[Remark] ntext,
	[QrType] nvarchar(50),
	[ProjectID] int
);

INSERT INTO [dbo].[Wechat_QrScene] (
	[Wechat_QrScene].[CreationTime],
	[Wechat_QrScene].[ExpiredTime],
	[Wechat_QrScene].[OpenID],
	[Wechat_QrScene].[Ticket],
	[Wechat_QrScene].[ScanUrl],
	[Wechat_QrScene].[PicUrl],
	[Wechat_QrScene].[SquarePicUrl],
	[Wechat_QrScene].[TeamID],
	[Wechat_QrScene].[QrName],
	[Wechat_QrScene].[Remark],
	[Wechat_QrScene].[QrType],
	[Wechat_QrScene].[ProjectID]
) 
output 
	INSERTED.[ID],
	INSERTED.[CreationTime],
	INSERTED.[ExpiredTime],
	INSERTED.[OpenID],
	INSERTED.[Ticket],
	INSERTED.[ScanUrl],
	INSERTED.[PicUrl],
	INSERTED.[SquarePicUrl],
	INSERTED.[TeamID],
	INSERTED.[QrName],
	INSERTED.[Remark],
	INSERTED.[QrType],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@CreationTime,
	@ExpiredTime,
	@OpenID,
	@Ticket,
	@ScanUrl,
	@PicUrl,
	@SquarePicUrl,
	@TeamID,
	@QrName,
	@Remark,
	@QrType,
	@ProjectID 
); 

SELECT 
	[ID],
	[CreationTime],
	[ExpiredTime],
	[OpenID],
	[Ticket],
	[ScanUrl],
	[PicUrl],
	[SquarePicUrl],
	[TeamID],
	[QrName],
	[Remark],
	[QrType],
	[ProjectID] 
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
	[CreationTime] datetime,
	[ExpiredTime] datetime,
	[OpenID] nvarchar(500),
	[Ticket] nvarchar(500),
	[ScanUrl] nvarchar(500),
	[PicUrl] nvarchar(500),
	[SquarePicUrl] nvarchar(500),
	[TeamID] int,
	[QrName] nvarchar(50),
	[Remark] ntext,
	[QrType] nvarchar(50),
	[ProjectID] int
);

UPDATE [dbo].[Wechat_QrScene] SET 
	[Wechat_QrScene].[CreationTime] = @CreationTime,
	[Wechat_QrScene].[ExpiredTime] = @ExpiredTime,
	[Wechat_QrScene].[OpenID] = @OpenID,
	[Wechat_QrScene].[Ticket] = @Ticket,
	[Wechat_QrScene].[ScanUrl] = @ScanUrl,
	[Wechat_QrScene].[PicUrl] = @PicUrl,
	[Wechat_QrScene].[SquarePicUrl] = @SquarePicUrl,
	[Wechat_QrScene].[TeamID] = @TeamID,
	[Wechat_QrScene].[QrName] = @QrName,
	[Wechat_QrScene].[Remark] = @Remark,
	[Wechat_QrScene].[QrType] = @QrType,
	[Wechat_QrScene].[ProjectID] = @ProjectID 
output 
	INSERTED.[ID],
	INSERTED.[CreationTime],
	INSERTED.[ExpiredTime],
	INSERTED.[OpenID],
	INSERTED.[Ticket],
	INSERTED.[ScanUrl],
	INSERTED.[PicUrl],
	INSERTED.[SquarePicUrl],
	INSERTED.[TeamID],
	INSERTED.[QrName],
	INSERTED.[Remark],
	INSERTED.[QrType],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Wechat_QrScene].[ID] = @ID

SELECT 
	[ID],
	[CreationTime],
	[ExpiredTime],
	[OpenID],
	[Ticket],
	[ScanUrl],
	[PicUrl],
	[SquarePicUrl],
	[TeamID],
	[QrName],
	[Remark],
	[QrType],
	[ProjectID] 
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
DELETE FROM [dbo].[Wechat_QrScene]
WHERE 
	[Wechat_QrScene].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_QrScene() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_QrScene(this.ID));
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
	[Wechat_QrScene].[ID],
	[Wechat_QrScene].[CreationTime],
	[Wechat_QrScene].[ExpiredTime],
	[Wechat_QrScene].[OpenID],
	[Wechat_QrScene].[Ticket],
	[Wechat_QrScene].[ScanUrl],
	[Wechat_QrScene].[PicUrl],
	[Wechat_QrScene].[SquarePicUrl],
	[Wechat_QrScene].[TeamID],
	[Wechat_QrScene].[QrName],
	[Wechat_QrScene].[Remark],
	[Wechat_QrScene].[QrType],
	[Wechat_QrScene].[ProjectID]
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
                return "Wechat_QrScene";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_QrScene into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="creationTime">creationTime</param>
		/// <param name="expiredTime">expiredTime</param>
		/// <param name="openID">openID</param>
		/// <param name="ticket">ticket</param>
		/// <param name="scanUrl">scanUrl</param>
		/// <param name="picUrl">picUrl</param>
		/// <param name="squarePicUrl">squarePicUrl</param>
		/// <param name="teamID">teamID</param>
		/// <param name="qrName">qrName</param>
		/// <param name="remark">remark</param>
		/// <param name="qrType">qrType</param>
		/// <param name="projectID">projectID</param>
		public static void InsertWechat_QrScene(DateTime @creationTime, DateTime @expiredTime, string @openID, string @ticket, string @scanUrl, string @picUrl, string @squarePicUrl, int @teamID, string @qrName, string @remark, string @qrType, int @projectID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_QrScene(@creationTime, @expiredTime, @openID, @ticket, @scanUrl, @picUrl, @squarePicUrl, @teamID, @qrName, @remark, @qrType, @projectID, helper);
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
		/// Insert a Wechat_QrScene into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="creationTime">creationTime</param>
		/// <param name="expiredTime">expiredTime</param>
		/// <param name="openID">openID</param>
		/// <param name="ticket">ticket</param>
		/// <param name="scanUrl">scanUrl</param>
		/// <param name="picUrl">picUrl</param>
		/// <param name="squarePicUrl">squarePicUrl</param>
		/// <param name="teamID">teamID</param>
		/// <param name="qrName">qrName</param>
		/// <param name="remark">remark</param>
		/// <param name="qrType">qrType</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_QrScene(DateTime @creationTime, DateTime @expiredTime, string @openID, string @ticket, string @scanUrl, string @picUrl, string @squarePicUrl, int @teamID, string @qrName, string @remark, string @qrType, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CreationTime] datetime,
	[ExpiredTime] datetime,
	[OpenID] nvarchar(500),
	[Ticket] nvarchar(500),
	[ScanUrl] nvarchar(500),
	[PicUrl] nvarchar(500),
	[SquarePicUrl] nvarchar(500),
	[TeamID] int,
	[QrName] nvarchar(50),
	[Remark] ntext,
	[QrType] nvarchar(50),
	[ProjectID] int
);

INSERT INTO [dbo].[Wechat_QrScene] (
	[Wechat_QrScene].[CreationTime],
	[Wechat_QrScene].[ExpiredTime],
	[Wechat_QrScene].[OpenID],
	[Wechat_QrScene].[Ticket],
	[Wechat_QrScene].[ScanUrl],
	[Wechat_QrScene].[PicUrl],
	[Wechat_QrScene].[SquarePicUrl],
	[Wechat_QrScene].[TeamID],
	[Wechat_QrScene].[QrName],
	[Wechat_QrScene].[Remark],
	[Wechat_QrScene].[QrType],
	[Wechat_QrScene].[ProjectID]
) 
output 
	INSERTED.[ID],
	INSERTED.[CreationTime],
	INSERTED.[ExpiredTime],
	INSERTED.[OpenID],
	INSERTED.[Ticket],
	INSERTED.[ScanUrl],
	INSERTED.[PicUrl],
	INSERTED.[SquarePicUrl],
	INSERTED.[TeamID],
	INSERTED.[QrName],
	INSERTED.[Remark],
	INSERTED.[QrType],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@CreationTime,
	@ExpiredTime,
	@OpenID,
	@Ticket,
	@ScanUrl,
	@PicUrl,
	@SquarePicUrl,
	@TeamID,
	@QrName,
	@Remark,
	@QrType,
	@ProjectID 
); 

SELECT 
	[ID],
	[CreationTime],
	[ExpiredTime],
	[OpenID],
	[Ticket],
	[ScanUrl],
	[PicUrl],
	[SquarePicUrl],
	[TeamID],
	[QrName],
	[Remark],
	[QrType],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CreationTime", EntityBase.GetDatabaseValue(@creationTime)));
			parameters.Add(new SqlParameter("@ExpiredTime", EntityBase.GetDatabaseValue(@expiredTime)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@Ticket", EntityBase.GetDatabaseValue(@ticket)));
			parameters.Add(new SqlParameter("@ScanUrl", EntityBase.GetDatabaseValue(@scanUrl)));
			parameters.Add(new SqlParameter("@PicUrl", EntityBase.GetDatabaseValue(@picUrl)));
			parameters.Add(new SqlParameter("@SquarePicUrl", EntityBase.GetDatabaseValue(@squarePicUrl)));
			parameters.Add(new SqlParameter("@TeamID", EntityBase.GetDatabaseValue(@teamID)));
			parameters.Add(new SqlParameter("@QrName", EntityBase.GetDatabaseValue(@qrName)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@QrType", EntityBase.GetDatabaseValue(@qrType)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_QrScene into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="creationTime">creationTime</param>
		/// <param name="expiredTime">expiredTime</param>
		/// <param name="openID">openID</param>
		/// <param name="ticket">ticket</param>
		/// <param name="scanUrl">scanUrl</param>
		/// <param name="picUrl">picUrl</param>
		/// <param name="squarePicUrl">squarePicUrl</param>
		/// <param name="teamID">teamID</param>
		/// <param name="qrName">qrName</param>
		/// <param name="remark">remark</param>
		/// <param name="qrType">qrType</param>
		/// <param name="projectID">projectID</param>
		public static void UpdateWechat_QrScene(int @iD, DateTime @creationTime, DateTime @expiredTime, string @openID, string @ticket, string @scanUrl, string @picUrl, string @squarePicUrl, int @teamID, string @qrName, string @remark, string @qrType, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_QrScene(@iD, @creationTime, @expiredTime, @openID, @ticket, @scanUrl, @picUrl, @squarePicUrl, @teamID, @qrName, @remark, @qrType, @projectID, helper);
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
		/// Updates a Wechat_QrScene into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="creationTime">creationTime</param>
		/// <param name="expiredTime">expiredTime</param>
		/// <param name="openID">openID</param>
		/// <param name="ticket">ticket</param>
		/// <param name="scanUrl">scanUrl</param>
		/// <param name="picUrl">picUrl</param>
		/// <param name="squarePicUrl">squarePicUrl</param>
		/// <param name="teamID">teamID</param>
		/// <param name="qrName">qrName</param>
		/// <param name="remark">remark</param>
		/// <param name="qrType">qrType</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_QrScene(int @iD, DateTime @creationTime, DateTime @expiredTime, string @openID, string @ticket, string @scanUrl, string @picUrl, string @squarePicUrl, int @teamID, string @qrName, string @remark, string @qrType, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CreationTime] datetime,
	[ExpiredTime] datetime,
	[OpenID] nvarchar(500),
	[Ticket] nvarchar(500),
	[ScanUrl] nvarchar(500),
	[PicUrl] nvarchar(500),
	[SquarePicUrl] nvarchar(500),
	[TeamID] int,
	[QrName] nvarchar(50),
	[Remark] ntext,
	[QrType] nvarchar(50),
	[ProjectID] int
);

UPDATE [dbo].[Wechat_QrScene] SET 
	[Wechat_QrScene].[CreationTime] = @CreationTime,
	[Wechat_QrScene].[ExpiredTime] = @ExpiredTime,
	[Wechat_QrScene].[OpenID] = @OpenID,
	[Wechat_QrScene].[Ticket] = @Ticket,
	[Wechat_QrScene].[ScanUrl] = @ScanUrl,
	[Wechat_QrScene].[PicUrl] = @PicUrl,
	[Wechat_QrScene].[SquarePicUrl] = @SquarePicUrl,
	[Wechat_QrScene].[TeamID] = @TeamID,
	[Wechat_QrScene].[QrName] = @QrName,
	[Wechat_QrScene].[Remark] = @Remark,
	[Wechat_QrScene].[QrType] = @QrType,
	[Wechat_QrScene].[ProjectID] = @ProjectID 
output 
	INSERTED.[ID],
	INSERTED.[CreationTime],
	INSERTED.[ExpiredTime],
	INSERTED.[OpenID],
	INSERTED.[Ticket],
	INSERTED.[ScanUrl],
	INSERTED.[PicUrl],
	INSERTED.[SquarePicUrl],
	INSERTED.[TeamID],
	INSERTED.[QrName],
	INSERTED.[Remark],
	INSERTED.[QrType],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Wechat_QrScene].[ID] = @ID

SELECT 
	[ID],
	[CreationTime],
	[ExpiredTime],
	[OpenID],
	[Ticket],
	[ScanUrl],
	[PicUrl],
	[SquarePicUrl],
	[TeamID],
	[QrName],
	[Remark],
	[QrType],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CreationTime", EntityBase.GetDatabaseValue(@creationTime)));
			parameters.Add(new SqlParameter("@ExpiredTime", EntityBase.GetDatabaseValue(@expiredTime)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@Ticket", EntityBase.GetDatabaseValue(@ticket)));
			parameters.Add(new SqlParameter("@ScanUrl", EntityBase.GetDatabaseValue(@scanUrl)));
			parameters.Add(new SqlParameter("@PicUrl", EntityBase.GetDatabaseValue(@picUrl)));
			parameters.Add(new SqlParameter("@SquarePicUrl", EntityBase.GetDatabaseValue(@squarePicUrl)));
			parameters.Add(new SqlParameter("@TeamID", EntityBase.GetDatabaseValue(@teamID)));
			parameters.Add(new SqlParameter("@QrName", EntityBase.GetDatabaseValue(@qrName)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@QrType", EntityBase.GetDatabaseValue(@qrType)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_QrScene from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_QrScene(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_QrScene(@iD, helper);
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
		/// Deletes a Wechat_QrScene from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_QrScene(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_QrScene]
WHERE 
	[Wechat_QrScene].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_QrScene object.
		/// </summary>
		/// <returns>The newly created Wechat_QrScene object.</returns>
		public static Wechat_QrScene CreateWechat_QrScene()
		{
			return InitializeNew<Wechat_QrScene>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_QrScene by a Wechat_QrScene's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_QrScene</returns>
		public static Wechat_QrScene GetWechat_QrScene(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_QrScene.SelectFieldList + @"
FROM [dbo].[Wechat_QrScene] 
WHERE 
	[Wechat_QrScene].[ID] = @ID " + Wechat_QrScene.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_QrScene>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_QrScene by a Wechat_QrScene's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_QrScene</returns>
		public static Wechat_QrScene GetWechat_QrScene(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_QrScene.SelectFieldList + @"
FROM [dbo].[Wechat_QrScene] 
WHERE 
	[Wechat_QrScene].[ID] = @ID " + Wechat_QrScene.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_QrScene>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_QrScene objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_QrScene objects.</returns>
		public static EntityList<Wechat_QrScene> GetWechat_QrScenes()
		{
			string commandText = @"
SELECT " + Wechat_QrScene.SelectFieldList + "FROM [dbo].[Wechat_QrScene] " + Wechat_QrScene.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_QrScene>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_QrScene objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_QrScene objects.</returns>
        public static EntityList<Wechat_QrScene> GetWechat_QrScenes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_QrScene>(SelectFieldList, "FROM [dbo].[Wechat_QrScene]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_QrScene objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_QrScene objects.</returns>
        public static EntityList<Wechat_QrScene> GetWechat_QrScenes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_QrScene>(SelectFieldList, "FROM [dbo].[Wechat_QrScene]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_QrScene objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_QrScene objects.</returns>
		protected static EntityList<Wechat_QrScene> GetWechat_QrScenes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_QrScenes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_QrScene objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_QrScene objects.</returns>
		protected static EntityList<Wechat_QrScene> GetWechat_QrScenes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_QrScenes(string.Empty, where, parameters, Wechat_QrScene.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_QrScene objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_QrScene objects.</returns>
		protected static EntityList<Wechat_QrScene> GetWechat_QrScenes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_QrScenes(prefix, where, parameters, Wechat_QrScene.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_QrScene objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_QrScene objects.</returns>
		protected static EntityList<Wechat_QrScene> GetWechat_QrScenes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_QrScenes(string.Empty, where, parameters, Wechat_QrScene.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_QrScene objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_QrScene objects.</returns>
		protected static EntityList<Wechat_QrScene> GetWechat_QrScenes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_QrScenes(prefix, where, parameters, Wechat_QrScene.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_QrScene objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_QrScene objects.</returns>
		protected static EntityList<Wechat_QrScene> GetWechat_QrScenes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_QrScene.SelectFieldList + "FROM [dbo].[Wechat_QrScene] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_QrScene>(reader);
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
        protected static EntityList<Wechat_QrScene> GetWechat_QrScenes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_QrScene>(SelectFieldList, "FROM [dbo].[Wechat_QrScene] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_QrScene objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_QrSceneCount()
        {
            return GetWechat_QrSceneCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_QrScene objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_QrSceneCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_QrScene] " + where;

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
		public static partial class Wechat_QrScene_Properties
		{
			public const string ID = "ID";
			public const string CreationTime = "CreationTime";
			public const string ExpiredTime = "ExpiredTime";
			public const string OpenID = "OpenID";
			public const string Ticket = "Ticket";
			public const string ScanUrl = "ScanUrl";
			public const string PicUrl = "PicUrl";
			public const string SquarePicUrl = "SquarePicUrl";
			public const string TeamID = "TeamID";
			public const string QrName = "QrName";
			public const string Remark = "Remark";
			public const string QrType = "QrType";
			public const string ProjectID = "ProjectID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CreationTime" , "DateTime:"},
    			 {"ExpiredTime" , "DateTime:"},
    			 {"OpenID" , "string:"},
    			 {"Ticket" , "string:"},
    			 {"ScanUrl" , "string:"},
    			 {"PicUrl" , "string:"},
    			 {"SquarePicUrl" , "string:"},
    			 {"TeamID" , "int:"},
    			 {"QrName" , "string:"},
    			 {"Remark" , "string:"},
    			 {"QrType" , "string:"},
    			 {"ProjectID" , "int:"},
            };
		}
		#endregion
	}
}
