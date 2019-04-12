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
	/// This object represents the properties and methods of a Mall_DoorRemoteQrCode.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_DoorRemoteQrCode 
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
		private int _doorDeviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int DoorDeviceID
		{
			[DebuggerStepThrough()]
			get { return this._doorDeviceID; }
			set 
			{
				if (this._doorDeviceID != value) 
				{
					this._doorDeviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DoorDeviceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _nickName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string NickName
		{
			[DebuggerStepThrough()]
			get { return this._nickName; }
			set 
			{
				if (this._nickName != value) 
				{
					this._nickName = value;
					this.IsDirty = true;	
					OnPropertyChanged("NickName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sex = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Sex
		{
			[DebuggerStepThrough()]
			get { return this._sex; }
			set 
			{
				if (this._sex != value) 
				{
					this._sex = value;
					this.IsDirty = true;	
					OnPropertyChanged("Sex");
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
		[DataObjectField(false, false, false)]
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
		[DataObjectField(false, false, false)]
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
		private int _endMinute = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int EndMinute
		{
			[DebuggerStepThrough()]
			get { return this._endMinute; }
			set 
			{
				if (this._endMinute != value) 
				{
					this._endMinute = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndMinute");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _lingLingID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string LingLingID
		{
			[DebuggerStepThrough()]
			get { return this._lingLingID; }
			set 
			{
				if (this._lingLingID != value) 
				{
					this._lingLingID = value;
					this.IsDirty = true;	
					OnPropertyChanged("LingLingID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _effecNumber = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int EffecNumber
		{
			[DebuggerStepThrough()]
			get { return this._effecNumber; }
			set 
			{
				if (this._effecNumber != value) 
				{
					this._effecNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("EffecNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _strKey = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string StrKey
		{
			[DebuggerStepThrough()]
			get { return this._strKey; }
			set 
			{
				if (this._strKey != value) 
				{
					this._strKey = value;
					this.IsDirty = true;	
					OnPropertyChanged("StrKey");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _useType = int.MinValue;
		/// <summary>
		/// 1-访客二维码 2-业主二维码
		/// </summary>
        [Description("1-访客二维码 2-业主二维码")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int UseType
		{
			[DebuggerStepThrough()]
			get { return this._useType; }
			set 
			{
				if (this._useType != value) 
				{
					this._useType = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseType");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _codeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CodeID
		{
			[DebuggerStepThrough()]
			get { return this._codeID; }
			set 
			{
				if (this._codeID != value) 
				{
					this._codeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CodeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _qrCodeKey = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string QrCodeKey
		{
			[DebuggerStepThrough()]
			get { return this._qrCodeKey; }
			set 
			{
				if (this._qrCodeKey != value) 
				{
					this._qrCodeKey = value;
					this.IsDirty = true;	
					OnPropertyChanged("QrCodeKey");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _qrCodePath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string QrCodePath
		{
			[DebuggerStepThrough()]
			get { return this._qrCodePath; }
			set 
			{
				if (this._qrCodePath != value) 
				{
					this._qrCodePath = value;
					this.IsDirty = true;	
					OnPropertyChanged("QrCodePath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _openCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OpenCount
		{
			[DebuggerStepThrough()]
			get { return this._openCount; }
			set 
			{
				if (this._openCount != value) 
				{
					this._openCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenCount");
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
	[DoorDeviceID] int,
	[NickName] nvarchar(100),
	[Sex] nvarchar(20),
	[StartTime] datetime,
	[EndTime] datetime,
	[EndMinute] int,
	[LingLingID] nvarchar(200),
	[EffecNumber] int,
	[StrKey] nvarchar(50),
	[UseType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[CodeID] int,
	[QrCodeKey] nvarchar(200),
	[QrCodePath] nvarchar(500),
	[OpenCount] int
);

INSERT INTO [dbo].[Mall_DoorRemoteQrCode] (
	[Mall_DoorRemoteQrCode].[DoorDeviceID],
	[Mall_DoorRemoteQrCode].[NickName],
	[Mall_DoorRemoteQrCode].[Sex],
	[Mall_DoorRemoteQrCode].[StartTime],
	[Mall_DoorRemoteQrCode].[EndTime],
	[Mall_DoorRemoteQrCode].[EndMinute],
	[Mall_DoorRemoteQrCode].[LingLingID],
	[Mall_DoorRemoteQrCode].[EffecNumber],
	[Mall_DoorRemoteQrCode].[StrKey],
	[Mall_DoorRemoteQrCode].[UseType],
	[Mall_DoorRemoteQrCode].[AddTime],
	[Mall_DoorRemoteQrCode].[AddUserName],
	[Mall_DoorRemoteQrCode].[CodeID],
	[Mall_DoorRemoteQrCode].[QrCodeKey],
	[Mall_DoorRemoteQrCode].[QrCodePath],
	[Mall_DoorRemoteQrCode].[OpenCount]
) 
output 
	INSERTED.[ID],
	INSERTED.[DoorDeviceID],
	INSERTED.[NickName],
	INSERTED.[Sex],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[EndMinute],
	INSERTED.[LingLingID],
	INSERTED.[EffecNumber],
	INSERTED.[StrKey],
	INSERTED.[UseType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[CodeID],
	INSERTED.[QrCodeKey],
	INSERTED.[QrCodePath],
	INSERTED.[OpenCount]
into @table
VALUES ( 
	@DoorDeviceID,
	@NickName,
	@Sex,
	@StartTime,
	@EndTime,
	@EndMinute,
	@LingLingID,
	@EffecNumber,
	@StrKey,
	@UseType,
	@AddTime,
	@AddUserName,
	@CodeID,
	@QrCodeKey,
	@QrCodePath,
	@OpenCount 
); 

SELECT 
	[ID],
	[DoorDeviceID],
	[NickName],
	[Sex],
	[StartTime],
	[EndTime],
	[EndMinute],
	[LingLingID],
	[EffecNumber],
	[StrKey],
	[UseType],
	[AddTime],
	[AddUserName],
	[CodeID],
	[QrCodeKey],
	[QrCodePath],
	[OpenCount] 
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
	[DoorDeviceID] int,
	[NickName] nvarchar(100),
	[Sex] nvarchar(20),
	[StartTime] datetime,
	[EndTime] datetime,
	[EndMinute] int,
	[LingLingID] nvarchar(200),
	[EffecNumber] int,
	[StrKey] nvarchar(50),
	[UseType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[CodeID] int,
	[QrCodeKey] nvarchar(200),
	[QrCodePath] nvarchar(500),
	[OpenCount] int
);

UPDATE [dbo].[Mall_DoorRemoteQrCode] SET 
	[Mall_DoorRemoteQrCode].[DoorDeviceID] = @DoorDeviceID,
	[Mall_DoorRemoteQrCode].[NickName] = @NickName,
	[Mall_DoorRemoteQrCode].[Sex] = @Sex,
	[Mall_DoorRemoteQrCode].[StartTime] = @StartTime,
	[Mall_DoorRemoteQrCode].[EndTime] = @EndTime,
	[Mall_DoorRemoteQrCode].[EndMinute] = @EndMinute,
	[Mall_DoorRemoteQrCode].[LingLingID] = @LingLingID,
	[Mall_DoorRemoteQrCode].[EffecNumber] = @EffecNumber,
	[Mall_DoorRemoteQrCode].[StrKey] = @StrKey,
	[Mall_DoorRemoteQrCode].[UseType] = @UseType,
	[Mall_DoorRemoteQrCode].[AddTime] = @AddTime,
	[Mall_DoorRemoteQrCode].[AddUserName] = @AddUserName,
	[Mall_DoorRemoteQrCode].[CodeID] = @CodeID,
	[Mall_DoorRemoteQrCode].[QrCodeKey] = @QrCodeKey,
	[Mall_DoorRemoteQrCode].[QrCodePath] = @QrCodePath,
	[Mall_DoorRemoteQrCode].[OpenCount] = @OpenCount 
output 
	INSERTED.[ID],
	INSERTED.[DoorDeviceID],
	INSERTED.[NickName],
	INSERTED.[Sex],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[EndMinute],
	INSERTED.[LingLingID],
	INSERTED.[EffecNumber],
	INSERTED.[StrKey],
	INSERTED.[UseType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[CodeID],
	INSERTED.[QrCodeKey],
	INSERTED.[QrCodePath],
	INSERTED.[OpenCount]
into @table
WHERE 
	[Mall_DoorRemoteQrCode].[ID] = @ID

SELECT 
	[ID],
	[DoorDeviceID],
	[NickName],
	[Sex],
	[StartTime],
	[EndTime],
	[EndMinute],
	[LingLingID],
	[EffecNumber],
	[StrKey],
	[UseType],
	[AddTime],
	[AddUserName],
	[CodeID],
	[QrCodeKey],
	[QrCodePath],
	[OpenCount] 
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
DELETE FROM [dbo].[Mall_DoorRemoteQrCode]
WHERE 
	[Mall_DoorRemoteQrCode].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_DoorRemoteQrCode() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_DoorRemoteQrCode(this.ID));
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
	[Mall_DoorRemoteQrCode].[ID],
	[Mall_DoorRemoteQrCode].[DoorDeviceID],
	[Mall_DoorRemoteQrCode].[NickName],
	[Mall_DoorRemoteQrCode].[Sex],
	[Mall_DoorRemoteQrCode].[StartTime],
	[Mall_DoorRemoteQrCode].[EndTime],
	[Mall_DoorRemoteQrCode].[EndMinute],
	[Mall_DoorRemoteQrCode].[LingLingID],
	[Mall_DoorRemoteQrCode].[EffecNumber],
	[Mall_DoorRemoteQrCode].[StrKey],
	[Mall_DoorRemoteQrCode].[UseType],
	[Mall_DoorRemoteQrCode].[AddTime],
	[Mall_DoorRemoteQrCode].[AddUserName],
	[Mall_DoorRemoteQrCode].[CodeID],
	[Mall_DoorRemoteQrCode].[QrCodeKey],
	[Mall_DoorRemoteQrCode].[QrCodePath],
	[Mall_DoorRemoteQrCode].[OpenCount]
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
                return "Mall_DoorRemoteQrCode";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_DoorRemoteQrCode into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="nickName">nickName</param>
		/// <param name="sex">sex</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="endMinute">endMinute</param>
		/// <param name="lingLingID">lingLingID</param>
		/// <param name="effecNumber">effecNumber</param>
		/// <param name="strKey">strKey</param>
		/// <param name="useType">useType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="codeID">codeID</param>
		/// <param name="qrCodeKey">qrCodeKey</param>
		/// <param name="qrCodePath">qrCodePath</param>
		/// <param name="openCount">openCount</param>
		public static void InsertMall_DoorRemoteQrCode(int @doorDeviceID, string @nickName, string @sex, DateTime @startTime, DateTime @endTime, int @endMinute, string @lingLingID, int @effecNumber, string @strKey, int @useType, DateTime @addTime, string @addUserName, int @codeID, string @qrCodeKey, string @qrCodePath, int @openCount)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_DoorRemoteQrCode(@doorDeviceID, @nickName, @sex, @startTime, @endTime, @endMinute, @lingLingID, @effecNumber, @strKey, @useType, @addTime, @addUserName, @codeID, @qrCodeKey, @qrCodePath, @openCount, helper);
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
		/// Insert a Mall_DoorRemoteQrCode into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="nickName">nickName</param>
		/// <param name="sex">sex</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="endMinute">endMinute</param>
		/// <param name="lingLingID">lingLingID</param>
		/// <param name="effecNumber">effecNumber</param>
		/// <param name="strKey">strKey</param>
		/// <param name="useType">useType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="codeID">codeID</param>
		/// <param name="qrCodeKey">qrCodeKey</param>
		/// <param name="qrCodePath">qrCodePath</param>
		/// <param name="openCount">openCount</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_DoorRemoteQrCode(int @doorDeviceID, string @nickName, string @sex, DateTime @startTime, DateTime @endTime, int @endMinute, string @lingLingID, int @effecNumber, string @strKey, int @useType, DateTime @addTime, string @addUserName, int @codeID, string @qrCodeKey, string @qrCodePath, int @openCount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DoorDeviceID] int,
	[NickName] nvarchar(100),
	[Sex] nvarchar(20),
	[StartTime] datetime,
	[EndTime] datetime,
	[EndMinute] int,
	[LingLingID] nvarchar(200),
	[EffecNumber] int,
	[StrKey] nvarchar(50),
	[UseType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[CodeID] int,
	[QrCodeKey] nvarchar(200),
	[QrCodePath] nvarchar(500),
	[OpenCount] int
);

INSERT INTO [dbo].[Mall_DoorRemoteQrCode] (
	[Mall_DoorRemoteQrCode].[DoorDeviceID],
	[Mall_DoorRemoteQrCode].[NickName],
	[Mall_DoorRemoteQrCode].[Sex],
	[Mall_DoorRemoteQrCode].[StartTime],
	[Mall_DoorRemoteQrCode].[EndTime],
	[Mall_DoorRemoteQrCode].[EndMinute],
	[Mall_DoorRemoteQrCode].[LingLingID],
	[Mall_DoorRemoteQrCode].[EffecNumber],
	[Mall_DoorRemoteQrCode].[StrKey],
	[Mall_DoorRemoteQrCode].[UseType],
	[Mall_DoorRemoteQrCode].[AddTime],
	[Mall_DoorRemoteQrCode].[AddUserName],
	[Mall_DoorRemoteQrCode].[CodeID],
	[Mall_DoorRemoteQrCode].[QrCodeKey],
	[Mall_DoorRemoteQrCode].[QrCodePath],
	[Mall_DoorRemoteQrCode].[OpenCount]
) 
output 
	INSERTED.[ID],
	INSERTED.[DoorDeviceID],
	INSERTED.[NickName],
	INSERTED.[Sex],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[EndMinute],
	INSERTED.[LingLingID],
	INSERTED.[EffecNumber],
	INSERTED.[StrKey],
	INSERTED.[UseType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[CodeID],
	INSERTED.[QrCodeKey],
	INSERTED.[QrCodePath],
	INSERTED.[OpenCount]
into @table
VALUES ( 
	@DoorDeviceID,
	@NickName,
	@Sex,
	@StartTime,
	@EndTime,
	@EndMinute,
	@LingLingID,
	@EffecNumber,
	@StrKey,
	@UseType,
	@AddTime,
	@AddUserName,
	@CodeID,
	@QrCodeKey,
	@QrCodePath,
	@OpenCount 
); 

SELECT 
	[ID],
	[DoorDeviceID],
	[NickName],
	[Sex],
	[StartTime],
	[EndTime],
	[EndMinute],
	[LingLingID],
	[EffecNumber],
	[StrKey],
	[UseType],
	[AddTime],
	[AddUserName],
	[CodeID],
	[QrCodeKey],
	[QrCodePath],
	[OpenCount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DoorDeviceID", EntityBase.GetDatabaseValue(@doorDeviceID)));
			parameters.Add(new SqlParameter("@NickName", EntityBase.GetDatabaseValue(@nickName)));
			parameters.Add(new SqlParameter("@Sex", EntityBase.GetDatabaseValue(@sex)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@EndMinute", EntityBase.GetDatabaseValue(@endMinute)));
			parameters.Add(new SqlParameter("@LingLingID", EntityBase.GetDatabaseValue(@lingLingID)));
			parameters.Add(new SqlParameter("@EffecNumber", EntityBase.GetDatabaseValue(@effecNumber)));
			parameters.Add(new SqlParameter("@StrKey", EntityBase.GetDatabaseValue(@strKey)));
			parameters.Add(new SqlParameter("@UseType", EntityBase.GetDatabaseValue(@useType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@CodeID", EntityBase.GetDatabaseValue(@codeID)));
			parameters.Add(new SqlParameter("@QrCodeKey", EntityBase.GetDatabaseValue(@qrCodeKey)));
			parameters.Add(new SqlParameter("@QrCodePath", EntityBase.GetDatabaseValue(@qrCodePath)));
			parameters.Add(new SqlParameter("@OpenCount", EntityBase.GetDatabaseValue(@openCount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_DoorRemoteQrCode into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="nickName">nickName</param>
		/// <param name="sex">sex</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="endMinute">endMinute</param>
		/// <param name="lingLingID">lingLingID</param>
		/// <param name="effecNumber">effecNumber</param>
		/// <param name="strKey">strKey</param>
		/// <param name="useType">useType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="codeID">codeID</param>
		/// <param name="qrCodeKey">qrCodeKey</param>
		/// <param name="qrCodePath">qrCodePath</param>
		/// <param name="openCount">openCount</param>
		public static void UpdateMall_DoorRemoteQrCode(int @iD, int @doorDeviceID, string @nickName, string @sex, DateTime @startTime, DateTime @endTime, int @endMinute, string @lingLingID, int @effecNumber, string @strKey, int @useType, DateTime @addTime, string @addUserName, int @codeID, string @qrCodeKey, string @qrCodePath, int @openCount)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_DoorRemoteQrCode(@iD, @doorDeviceID, @nickName, @sex, @startTime, @endTime, @endMinute, @lingLingID, @effecNumber, @strKey, @useType, @addTime, @addUserName, @codeID, @qrCodeKey, @qrCodePath, @openCount, helper);
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
		/// Updates a Mall_DoorRemoteQrCode into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="nickName">nickName</param>
		/// <param name="sex">sex</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="endMinute">endMinute</param>
		/// <param name="lingLingID">lingLingID</param>
		/// <param name="effecNumber">effecNumber</param>
		/// <param name="strKey">strKey</param>
		/// <param name="useType">useType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="codeID">codeID</param>
		/// <param name="qrCodeKey">qrCodeKey</param>
		/// <param name="qrCodePath">qrCodePath</param>
		/// <param name="openCount">openCount</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_DoorRemoteQrCode(int @iD, int @doorDeviceID, string @nickName, string @sex, DateTime @startTime, DateTime @endTime, int @endMinute, string @lingLingID, int @effecNumber, string @strKey, int @useType, DateTime @addTime, string @addUserName, int @codeID, string @qrCodeKey, string @qrCodePath, int @openCount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DoorDeviceID] int,
	[NickName] nvarchar(100),
	[Sex] nvarchar(20),
	[StartTime] datetime,
	[EndTime] datetime,
	[EndMinute] int,
	[LingLingID] nvarchar(200),
	[EffecNumber] int,
	[StrKey] nvarchar(50),
	[UseType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[CodeID] int,
	[QrCodeKey] nvarchar(200),
	[QrCodePath] nvarchar(500),
	[OpenCount] int
);

UPDATE [dbo].[Mall_DoorRemoteQrCode] SET 
	[Mall_DoorRemoteQrCode].[DoorDeviceID] = @DoorDeviceID,
	[Mall_DoorRemoteQrCode].[NickName] = @NickName,
	[Mall_DoorRemoteQrCode].[Sex] = @Sex,
	[Mall_DoorRemoteQrCode].[StartTime] = @StartTime,
	[Mall_DoorRemoteQrCode].[EndTime] = @EndTime,
	[Mall_DoorRemoteQrCode].[EndMinute] = @EndMinute,
	[Mall_DoorRemoteQrCode].[LingLingID] = @LingLingID,
	[Mall_DoorRemoteQrCode].[EffecNumber] = @EffecNumber,
	[Mall_DoorRemoteQrCode].[StrKey] = @StrKey,
	[Mall_DoorRemoteQrCode].[UseType] = @UseType,
	[Mall_DoorRemoteQrCode].[AddTime] = @AddTime,
	[Mall_DoorRemoteQrCode].[AddUserName] = @AddUserName,
	[Mall_DoorRemoteQrCode].[CodeID] = @CodeID,
	[Mall_DoorRemoteQrCode].[QrCodeKey] = @QrCodeKey,
	[Mall_DoorRemoteQrCode].[QrCodePath] = @QrCodePath,
	[Mall_DoorRemoteQrCode].[OpenCount] = @OpenCount 
output 
	INSERTED.[ID],
	INSERTED.[DoorDeviceID],
	INSERTED.[NickName],
	INSERTED.[Sex],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[EndMinute],
	INSERTED.[LingLingID],
	INSERTED.[EffecNumber],
	INSERTED.[StrKey],
	INSERTED.[UseType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[CodeID],
	INSERTED.[QrCodeKey],
	INSERTED.[QrCodePath],
	INSERTED.[OpenCount]
into @table
WHERE 
	[Mall_DoorRemoteQrCode].[ID] = @ID

SELECT 
	[ID],
	[DoorDeviceID],
	[NickName],
	[Sex],
	[StartTime],
	[EndTime],
	[EndMinute],
	[LingLingID],
	[EffecNumber],
	[StrKey],
	[UseType],
	[AddTime],
	[AddUserName],
	[CodeID],
	[QrCodeKey],
	[QrCodePath],
	[OpenCount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DoorDeviceID", EntityBase.GetDatabaseValue(@doorDeviceID)));
			parameters.Add(new SqlParameter("@NickName", EntityBase.GetDatabaseValue(@nickName)));
			parameters.Add(new SqlParameter("@Sex", EntityBase.GetDatabaseValue(@sex)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@EndMinute", EntityBase.GetDatabaseValue(@endMinute)));
			parameters.Add(new SqlParameter("@LingLingID", EntityBase.GetDatabaseValue(@lingLingID)));
			parameters.Add(new SqlParameter("@EffecNumber", EntityBase.GetDatabaseValue(@effecNumber)));
			parameters.Add(new SqlParameter("@StrKey", EntityBase.GetDatabaseValue(@strKey)));
			parameters.Add(new SqlParameter("@UseType", EntityBase.GetDatabaseValue(@useType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@CodeID", EntityBase.GetDatabaseValue(@codeID)));
			parameters.Add(new SqlParameter("@QrCodeKey", EntityBase.GetDatabaseValue(@qrCodeKey)));
			parameters.Add(new SqlParameter("@QrCodePath", EntityBase.GetDatabaseValue(@qrCodePath)));
			parameters.Add(new SqlParameter("@OpenCount", EntityBase.GetDatabaseValue(@openCount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_DoorRemoteQrCode from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_DoorRemoteQrCode(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_DoorRemoteQrCode(@iD, helper);
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
		/// Deletes a Mall_DoorRemoteQrCode from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_DoorRemoteQrCode(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_DoorRemoteQrCode]
WHERE 
	[Mall_DoorRemoteQrCode].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_DoorRemoteQrCode object.
		/// </summary>
		/// <returns>The newly created Mall_DoorRemoteQrCode object.</returns>
		public static Mall_DoorRemoteQrCode CreateMall_DoorRemoteQrCode()
		{
			return InitializeNew<Mall_DoorRemoteQrCode>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_DoorRemoteQrCode by a Mall_DoorRemoteQrCode's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_DoorRemoteQrCode</returns>
		public static Mall_DoorRemoteQrCode GetMall_DoorRemoteQrCode(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_DoorRemoteQrCode.SelectFieldList + @"
FROM [dbo].[Mall_DoorRemoteQrCode] 
WHERE 
	[Mall_DoorRemoteQrCode].[ID] = @ID " + Mall_DoorRemoteQrCode.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorRemoteQrCode>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_DoorRemoteQrCode by a Mall_DoorRemoteQrCode's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_DoorRemoteQrCode</returns>
		public static Mall_DoorRemoteQrCode GetMall_DoorRemoteQrCode(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_DoorRemoteQrCode.SelectFieldList + @"
FROM [dbo].[Mall_DoorRemoteQrCode] 
WHERE 
	[Mall_DoorRemoteQrCode].[ID] = @ID " + Mall_DoorRemoteQrCode.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorRemoteQrCode>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCode objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCode objects.</returns>
		public static EntityList<Mall_DoorRemoteQrCode> GetMall_DoorRemoteQrCodes()
		{
			string commandText = @"
SELECT " + Mall_DoorRemoteQrCode.SelectFieldList + "FROM [dbo].[Mall_DoorRemoteQrCode] " + Mall_DoorRemoteQrCode.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_DoorRemoteQrCode>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_DoorRemoteQrCode objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorRemoteQrCode objects.</returns>
        public static EntityList<Mall_DoorRemoteQrCode> GetMall_DoorRemoteQrCodes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteQrCode>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteQrCode]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_DoorRemoteQrCode objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorRemoteQrCode objects.</returns>
        public static EntityList<Mall_DoorRemoteQrCode> GetMall_DoorRemoteQrCodes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteQrCode>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteQrCode]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCode objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCode objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCode> GetMall_DoorRemoteQrCodes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteQrCodes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCode objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCode objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCode> GetMall_DoorRemoteQrCodes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteQrCodes(string.Empty, where, parameters, Mall_DoorRemoteQrCode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCode objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCode objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCode> GetMall_DoorRemoteQrCodes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteQrCodes(prefix, where, parameters, Mall_DoorRemoteQrCode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCode objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCode objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCode> GetMall_DoorRemoteQrCodes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorRemoteQrCodes(string.Empty, where, parameters, Mall_DoorRemoteQrCode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCode objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCode objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCode> GetMall_DoorRemoteQrCodes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorRemoteQrCodes(prefix, where, parameters, Mall_DoorRemoteQrCode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCode objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCode objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCode> GetMall_DoorRemoteQrCodes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_DoorRemoteQrCode.SelectFieldList + "FROM [dbo].[Mall_DoorRemoteQrCode] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_DoorRemoteQrCode>(reader);
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
        protected static EntityList<Mall_DoorRemoteQrCode> GetMall_DoorRemoteQrCodes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteQrCode>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteQrCode] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_DoorRemoteQrCode objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorRemoteQrCodeCount()
        {
            return GetMall_DoorRemoteQrCodeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_DoorRemoteQrCode objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorRemoteQrCodeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_DoorRemoteQrCode] " + where;

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
		public static partial class Mall_DoorRemoteQrCode_Properties
		{
			public const string ID = "ID";
			public const string DoorDeviceID = "DoorDeviceID";
			public const string NickName = "NickName";
			public const string Sex = "Sex";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string EndMinute = "EndMinute";
			public const string LingLingID = "LingLingID";
			public const string EffecNumber = "EffecNumber";
			public const string StrKey = "StrKey";
			public const string UseType = "UseType";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string CodeID = "CodeID";
			public const string QrCodeKey = "QrCodeKey";
			public const string QrCodePath = "QrCodePath";
			public const string OpenCount = "OpenCount";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DoorDeviceID" , "int:"},
    			 {"NickName" , "string:"},
    			 {"Sex" , "string:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"EndMinute" , "int:"},
    			 {"LingLingID" , "string:"},
    			 {"EffecNumber" , "int:"},
    			 {"StrKey" , "string:"},
    			 {"UseType" , "int:1-访客二维码 2-业主二维码"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"CodeID" , "int:"},
    			 {"QrCodeKey" , "string:"},
    			 {"QrCodePath" , "string:"},
    			 {"OpenCount" , "int:"},
            };
		}
		#endregion
	}
}
