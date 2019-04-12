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
	/// This object represents the properties and methods of a Wechat_HouseService.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_HouseService 
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
		private string _title = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Title
		{
			[DebuggerStepThrough()]
			get { return this._title; }
			set 
			{
				if (this._title != value) 
				{
					this._title = value;
					this.IsDirty = true;	
					OnPropertyChanged("Title");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contactPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ContactPhone
		{
			[DebuggerStepThrough()]
			get { return this._contactPhone; }
			set 
			{
				if (this._contactPhone != value) 
				{
					this._contactPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContactPhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceIncude = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceIncude
		{
			[DebuggerStepThrough()]
			get { return this._serviceIncude; }
			set 
			{
				if (this._serviceIncude != value) 
				{
					this._serviceIncude = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceIncude");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceStandard = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceStandard
		{
			[DebuggerStepThrough()]
			get { return this._serviceStandard; }
			set 
			{
				if (this._serviceStandard != value) 
				{
					this._serviceStandard = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceStandard");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _appointNotify = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AppointNotify
		{
			[DebuggerStepThrough()]
			get { return this._appointNotify; }
			set 
			{
				if (this._appointNotify != value) 
				{
					this._appointNotify = value;
					this.IsDirty = true;	
					OnPropertyChanged("AppointNotify");
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
		private int _categoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CategoryID
		{
			[DebuggerStepThrough()]
			get { return this._categoryID; }
			set 
			{
				if (this._categoryID != value) 
				{
					this._categoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPublish = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPublish
		{
			[DebuggerStepThrough()]
			get { return this._isPublish; }
			set 
			{
				if (this._isPublish != value) 
				{
					this._isPublish = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPublish");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _iconLink = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IconLink
		{
			[DebuggerStepThrough()]
			get { return this._iconLink; }
			set 
			{
				if (this._iconLink != value) 
				{
					this._iconLink = value;
					this.IsDirty = true;	
					OnPropertyChanged("IconLink");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _serviceType = int.MinValue;
		/// <summary>
		/// 1-微信服务 2-APP业主服务
		/// </summary>
        [Description("1-微信服务 2-APP业主服务")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceType
		{
			[DebuggerStepThrough()]
			get { return this._serviceType; }
			set 
			{
				if (this._serviceType != value) 
				{
					this._serviceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceType");
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
		private bool _isWechatShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsWechatShow
		{
			[DebuggerStepThrough()]
			get { return this._isWechatShow; }
			set 
			{
				if (this._isWechatShow != value) 
				{
					this._isWechatShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsWechatShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPUserShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPUserShow
		{
			[DebuggerStepThrough()]
			get { return this._isAPPUserShow; }
			set 
			{
				if (this._isAPPUserShow != value) 
				{
					this._isAPPUserShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPUserShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPCustomerShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPCustomerShow
		{
			[DebuggerStepThrough()]
			get { return this._isAPPCustomerShow; }
			set 
			{
				if (this._isAPPCustomerShow != value) 
				{
					this._isAPPCustomerShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPCustomerShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _useOutLink = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool UseOutLink
		{
			[DebuggerStepThrough()]
			get { return this._useOutLink; }
			set 
			{
				if (this._useOutLink != value) 
				{
					this._useOutLink = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseOutLink");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _outLinkURL = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OutLinkURL
		{
			[DebuggerStepThrough()]
			get { return this._outLinkURL; }
			set 
			{
				if (this._outLinkURL != value) 
				{
					this._outLinkURL = value;
					this.IsDirty = true;	
					OnPropertyChanged("OutLinkURL");
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
	[Title] nvarchar(200),
	[ContactPhone] nvarchar(50),
	[ServiceIncude] ntext,
	[ServiceStandard] ntext,
	[AppointNotify] ntext,
	[AddTime] datetime,
	[CategoryID] int,
	[IsPublish] bit,
	[IconLink] nvarchar(500),
	[ServiceType] int,
	[SortOrder] int,
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[UseOutLink] bit,
	[OutLinkURL] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_HouseService] (
	[Wechat_HouseService].[Title],
	[Wechat_HouseService].[ContactPhone],
	[Wechat_HouseService].[ServiceIncude],
	[Wechat_HouseService].[ServiceStandard],
	[Wechat_HouseService].[AppointNotify],
	[Wechat_HouseService].[AddTime],
	[Wechat_HouseService].[CategoryID],
	[Wechat_HouseService].[IsPublish],
	[Wechat_HouseService].[IconLink],
	[Wechat_HouseService].[ServiceType],
	[Wechat_HouseService].[SortOrder],
	[Wechat_HouseService].[IsWechatShow],
	[Wechat_HouseService].[IsAPPUserShow],
	[Wechat_HouseService].[IsAPPCustomerShow],
	[Wechat_HouseService].[UseOutLink],
	[Wechat_HouseService].[OutLinkURL]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[ContactPhone],
	INSERTED.[ServiceIncude],
	INSERTED.[ServiceStandard],
	INSERTED.[AppointNotify],
	INSERTED.[AddTime],
	INSERTED.[CategoryID],
	INSERTED.[IsPublish],
	INSERTED.[IconLink],
	INSERTED.[ServiceType],
	INSERTED.[SortOrder],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[UseOutLink],
	INSERTED.[OutLinkURL]
into @table
VALUES ( 
	@Title,
	@ContactPhone,
	@ServiceIncude,
	@ServiceStandard,
	@AppointNotify,
	@AddTime,
	@CategoryID,
	@IsPublish,
	@IconLink,
	@ServiceType,
	@SortOrder,
	@IsWechatShow,
	@IsAPPUserShow,
	@IsAPPCustomerShow,
	@UseOutLink,
	@OutLinkURL 
); 

SELECT 
	[ID],
	[Title],
	[ContactPhone],
	[ServiceIncude],
	[ServiceStandard],
	[AppointNotify],
	[AddTime],
	[CategoryID],
	[IsPublish],
	[IconLink],
	[ServiceType],
	[SortOrder],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[UseOutLink],
	[OutLinkURL] 
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
	[Title] nvarchar(200),
	[ContactPhone] nvarchar(50),
	[ServiceIncude] ntext,
	[ServiceStandard] ntext,
	[AppointNotify] ntext,
	[AddTime] datetime,
	[CategoryID] int,
	[IsPublish] bit,
	[IconLink] nvarchar(500),
	[ServiceType] int,
	[SortOrder] int,
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[UseOutLink] bit,
	[OutLinkURL] nvarchar(500)
);

UPDATE [dbo].[Wechat_HouseService] SET 
	[Wechat_HouseService].[Title] = @Title,
	[Wechat_HouseService].[ContactPhone] = @ContactPhone,
	[Wechat_HouseService].[ServiceIncude] = @ServiceIncude,
	[Wechat_HouseService].[ServiceStandard] = @ServiceStandard,
	[Wechat_HouseService].[AppointNotify] = @AppointNotify,
	[Wechat_HouseService].[AddTime] = @AddTime,
	[Wechat_HouseService].[CategoryID] = @CategoryID,
	[Wechat_HouseService].[IsPublish] = @IsPublish,
	[Wechat_HouseService].[IconLink] = @IconLink,
	[Wechat_HouseService].[ServiceType] = @ServiceType,
	[Wechat_HouseService].[SortOrder] = @SortOrder,
	[Wechat_HouseService].[IsWechatShow] = @IsWechatShow,
	[Wechat_HouseService].[IsAPPUserShow] = @IsAPPUserShow,
	[Wechat_HouseService].[IsAPPCustomerShow] = @IsAPPCustomerShow,
	[Wechat_HouseService].[UseOutLink] = @UseOutLink,
	[Wechat_HouseService].[OutLinkURL] = @OutLinkURL 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[ContactPhone],
	INSERTED.[ServiceIncude],
	INSERTED.[ServiceStandard],
	INSERTED.[AppointNotify],
	INSERTED.[AddTime],
	INSERTED.[CategoryID],
	INSERTED.[IsPublish],
	INSERTED.[IconLink],
	INSERTED.[ServiceType],
	INSERTED.[SortOrder],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[UseOutLink],
	INSERTED.[OutLinkURL]
into @table
WHERE 
	[Wechat_HouseService].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[ContactPhone],
	[ServiceIncude],
	[ServiceStandard],
	[AppointNotify],
	[AddTime],
	[CategoryID],
	[IsPublish],
	[IconLink],
	[ServiceType],
	[SortOrder],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[UseOutLink],
	[OutLinkURL] 
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
DELETE FROM [dbo].[Wechat_HouseService]
WHERE 
	[Wechat_HouseService].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_HouseService() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_HouseService(this.ID));
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
	[Wechat_HouseService].[ID],
	[Wechat_HouseService].[Title],
	[Wechat_HouseService].[ContactPhone],
	[Wechat_HouseService].[ServiceIncude],
	[Wechat_HouseService].[ServiceStandard],
	[Wechat_HouseService].[AppointNotify],
	[Wechat_HouseService].[AddTime],
	[Wechat_HouseService].[CategoryID],
	[Wechat_HouseService].[IsPublish],
	[Wechat_HouseService].[IconLink],
	[Wechat_HouseService].[ServiceType],
	[Wechat_HouseService].[SortOrder],
	[Wechat_HouseService].[IsWechatShow],
	[Wechat_HouseService].[IsAPPUserShow],
	[Wechat_HouseService].[IsAPPCustomerShow],
	[Wechat_HouseService].[UseOutLink],
	[Wechat_HouseService].[OutLinkURL]
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
                return "Wechat_HouseService";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_HouseService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="serviceIncude">serviceIncude</param>
		/// <param name="serviceStandard">serviceStandard</param>
		/// <param name="appointNotify">appointNotify</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="isPublish">isPublish</param>
		/// <param name="iconLink">iconLink</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="useOutLink">useOutLink</param>
		/// <param name="outLinkURL">outLinkURL</param>
		public static void InsertWechat_HouseService(string @title, string @contactPhone, string @serviceIncude, string @serviceStandard, string @appointNotify, DateTime @addTime, int @categoryID, bool @isPublish, string @iconLink, int @serviceType, int @sortOrder, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, bool @useOutLink, string @outLinkURL)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_HouseService(@title, @contactPhone, @serviceIncude, @serviceStandard, @appointNotify, @addTime, @categoryID, @isPublish, @iconLink, @serviceType, @sortOrder, @isWechatShow, @isAPPUserShow, @isAPPCustomerShow, @useOutLink, @outLinkURL, helper);
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
		/// Insert a Wechat_HouseService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="serviceIncude">serviceIncude</param>
		/// <param name="serviceStandard">serviceStandard</param>
		/// <param name="appointNotify">appointNotify</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="isPublish">isPublish</param>
		/// <param name="iconLink">iconLink</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="useOutLink">useOutLink</param>
		/// <param name="outLinkURL">outLinkURL</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_HouseService(string @title, string @contactPhone, string @serviceIncude, string @serviceStandard, string @appointNotify, DateTime @addTime, int @categoryID, bool @isPublish, string @iconLink, int @serviceType, int @sortOrder, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, bool @useOutLink, string @outLinkURL, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(200),
	[ContactPhone] nvarchar(50),
	[ServiceIncude] ntext,
	[ServiceStandard] ntext,
	[AppointNotify] ntext,
	[AddTime] datetime,
	[CategoryID] int,
	[IsPublish] bit,
	[IconLink] nvarchar(500),
	[ServiceType] int,
	[SortOrder] int,
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[UseOutLink] bit,
	[OutLinkURL] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_HouseService] (
	[Wechat_HouseService].[Title],
	[Wechat_HouseService].[ContactPhone],
	[Wechat_HouseService].[ServiceIncude],
	[Wechat_HouseService].[ServiceStandard],
	[Wechat_HouseService].[AppointNotify],
	[Wechat_HouseService].[AddTime],
	[Wechat_HouseService].[CategoryID],
	[Wechat_HouseService].[IsPublish],
	[Wechat_HouseService].[IconLink],
	[Wechat_HouseService].[ServiceType],
	[Wechat_HouseService].[SortOrder],
	[Wechat_HouseService].[IsWechatShow],
	[Wechat_HouseService].[IsAPPUserShow],
	[Wechat_HouseService].[IsAPPCustomerShow],
	[Wechat_HouseService].[UseOutLink],
	[Wechat_HouseService].[OutLinkURL]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[ContactPhone],
	INSERTED.[ServiceIncude],
	INSERTED.[ServiceStandard],
	INSERTED.[AppointNotify],
	INSERTED.[AddTime],
	INSERTED.[CategoryID],
	INSERTED.[IsPublish],
	INSERTED.[IconLink],
	INSERTED.[ServiceType],
	INSERTED.[SortOrder],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[UseOutLink],
	INSERTED.[OutLinkURL]
into @table
VALUES ( 
	@Title,
	@ContactPhone,
	@ServiceIncude,
	@ServiceStandard,
	@AppointNotify,
	@AddTime,
	@CategoryID,
	@IsPublish,
	@IconLink,
	@ServiceType,
	@SortOrder,
	@IsWechatShow,
	@IsAPPUserShow,
	@IsAPPCustomerShow,
	@UseOutLink,
	@OutLinkURL 
); 

SELECT 
	[ID],
	[Title],
	[ContactPhone],
	[ServiceIncude],
	[ServiceStandard],
	[AppointNotify],
	[AddTime],
	[CategoryID],
	[IsPublish],
	[IconLink],
	[ServiceType],
	[SortOrder],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[UseOutLink],
	[OutLinkURL] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@ContactPhone", EntityBase.GetDatabaseValue(@contactPhone)));
			parameters.Add(new SqlParameter("@ServiceIncude", EntityBase.GetDatabaseValue(@serviceIncude)));
			parameters.Add(new SqlParameter("@ServiceStandard", EntityBase.GetDatabaseValue(@serviceStandard)));
			parameters.Add(new SqlParameter("@AppointNotify", EntityBase.GetDatabaseValue(@appointNotify)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@IsPublish", @isPublish));
			parameters.Add(new SqlParameter("@IconLink", EntityBase.GetDatabaseValue(@iconLink)));
			parameters.Add(new SqlParameter("@ServiceType", EntityBase.GetDatabaseValue(@serviceType)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsWechatShow", @isWechatShow));
			parameters.Add(new SqlParameter("@IsAPPUserShow", @isAPPUserShow));
			parameters.Add(new SqlParameter("@IsAPPCustomerShow", @isAPPCustomerShow));
			parameters.Add(new SqlParameter("@UseOutLink", @useOutLink));
			parameters.Add(new SqlParameter("@OutLinkURL", EntityBase.GetDatabaseValue(@outLinkURL)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_HouseService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="serviceIncude">serviceIncude</param>
		/// <param name="serviceStandard">serviceStandard</param>
		/// <param name="appointNotify">appointNotify</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="isPublish">isPublish</param>
		/// <param name="iconLink">iconLink</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="useOutLink">useOutLink</param>
		/// <param name="outLinkURL">outLinkURL</param>
		public static void UpdateWechat_HouseService(int @iD, string @title, string @contactPhone, string @serviceIncude, string @serviceStandard, string @appointNotify, DateTime @addTime, int @categoryID, bool @isPublish, string @iconLink, int @serviceType, int @sortOrder, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, bool @useOutLink, string @outLinkURL)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_HouseService(@iD, @title, @contactPhone, @serviceIncude, @serviceStandard, @appointNotify, @addTime, @categoryID, @isPublish, @iconLink, @serviceType, @sortOrder, @isWechatShow, @isAPPUserShow, @isAPPCustomerShow, @useOutLink, @outLinkURL, helper);
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
		/// Updates a Wechat_HouseService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="serviceIncude">serviceIncude</param>
		/// <param name="serviceStandard">serviceStandard</param>
		/// <param name="appointNotify">appointNotify</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="isPublish">isPublish</param>
		/// <param name="iconLink">iconLink</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="useOutLink">useOutLink</param>
		/// <param name="outLinkURL">outLinkURL</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_HouseService(int @iD, string @title, string @contactPhone, string @serviceIncude, string @serviceStandard, string @appointNotify, DateTime @addTime, int @categoryID, bool @isPublish, string @iconLink, int @serviceType, int @sortOrder, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, bool @useOutLink, string @outLinkURL, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(200),
	[ContactPhone] nvarchar(50),
	[ServiceIncude] ntext,
	[ServiceStandard] ntext,
	[AppointNotify] ntext,
	[AddTime] datetime,
	[CategoryID] int,
	[IsPublish] bit,
	[IconLink] nvarchar(500),
	[ServiceType] int,
	[SortOrder] int,
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[UseOutLink] bit,
	[OutLinkURL] nvarchar(500)
);

UPDATE [dbo].[Wechat_HouseService] SET 
	[Wechat_HouseService].[Title] = @Title,
	[Wechat_HouseService].[ContactPhone] = @ContactPhone,
	[Wechat_HouseService].[ServiceIncude] = @ServiceIncude,
	[Wechat_HouseService].[ServiceStandard] = @ServiceStandard,
	[Wechat_HouseService].[AppointNotify] = @AppointNotify,
	[Wechat_HouseService].[AddTime] = @AddTime,
	[Wechat_HouseService].[CategoryID] = @CategoryID,
	[Wechat_HouseService].[IsPublish] = @IsPublish,
	[Wechat_HouseService].[IconLink] = @IconLink,
	[Wechat_HouseService].[ServiceType] = @ServiceType,
	[Wechat_HouseService].[SortOrder] = @SortOrder,
	[Wechat_HouseService].[IsWechatShow] = @IsWechatShow,
	[Wechat_HouseService].[IsAPPUserShow] = @IsAPPUserShow,
	[Wechat_HouseService].[IsAPPCustomerShow] = @IsAPPCustomerShow,
	[Wechat_HouseService].[UseOutLink] = @UseOutLink,
	[Wechat_HouseService].[OutLinkURL] = @OutLinkURL 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[ContactPhone],
	INSERTED.[ServiceIncude],
	INSERTED.[ServiceStandard],
	INSERTED.[AppointNotify],
	INSERTED.[AddTime],
	INSERTED.[CategoryID],
	INSERTED.[IsPublish],
	INSERTED.[IconLink],
	INSERTED.[ServiceType],
	INSERTED.[SortOrder],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[UseOutLink],
	INSERTED.[OutLinkURL]
into @table
WHERE 
	[Wechat_HouseService].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[ContactPhone],
	[ServiceIncude],
	[ServiceStandard],
	[AppointNotify],
	[AddTime],
	[CategoryID],
	[IsPublish],
	[IconLink],
	[ServiceType],
	[SortOrder],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[UseOutLink],
	[OutLinkURL] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@ContactPhone", EntityBase.GetDatabaseValue(@contactPhone)));
			parameters.Add(new SqlParameter("@ServiceIncude", EntityBase.GetDatabaseValue(@serviceIncude)));
			parameters.Add(new SqlParameter("@ServiceStandard", EntityBase.GetDatabaseValue(@serviceStandard)));
			parameters.Add(new SqlParameter("@AppointNotify", EntityBase.GetDatabaseValue(@appointNotify)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@IsPublish", @isPublish));
			parameters.Add(new SqlParameter("@IconLink", EntityBase.GetDatabaseValue(@iconLink)));
			parameters.Add(new SqlParameter("@ServiceType", EntityBase.GetDatabaseValue(@serviceType)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsWechatShow", @isWechatShow));
			parameters.Add(new SqlParameter("@IsAPPUserShow", @isAPPUserShow));
			parameters.Add(new SqlParameter("@IsAPPCustomerShow", @isAPPCustomerShow));
			parameters.Add(new SqlParameter("@UseOutLink", @useOutLink));
			parameters.Add(new SqlParameter("@OutLinkURL", EntityBase.GetDatabaseValue(@outLinkURL)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_HouseService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_HouseService(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_HouseService(@iD, helper);
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
		/// Deletes a Wechat_HouseService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_HouseService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_HouseService]
WHERE 
	[Wechat_HouseService].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_HouseService object.
		/// </summary>
		/// <returns>The newly created Wechat_HouseService object.</returns>
		public static Wechat_HouseService CreateWechat_HouseService()
		{
			return InitializeNew<Wechat_HouseService>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_HouseService by a Wechat_HouseService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_HouseService</returns>
		public static Wechat_HouseService GetWechat_HouseService(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_HouseService.SelectFieldList + @"
FROM [dbo].[Wechat_HouseService] 
WHERE 
	[Wechat_HouseService].[ID] = @ID " + Wechat_HouseService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_HouseService>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_HouseService by a Wechat_HouseService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_HouseService</returns>
		public static Wechat_HouseService GetWechat_HouseService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_HouseService.SelectFieldList + @"
FROM [dbo].[Wechat_HouseService] 
WHERE 
	[Wechat_HouseService].[ID] = @ID " + Wechat_HouseService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_HouseService>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseService objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_HouseService objects.</returns>
		public static EntityList<Wechat_HouseService> GetWechat_HouseServices()
		{
			string commandText = @"
SELECT " + Wechat_HouseService.SelectFieldList + "FROM [dbo].[Wechat_HouseService] " + Wechat_HouseService.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_HouseService>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_HouseService objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_HouseService objects.</returns>
        public static EntityList<Wechat_HouseService> GetWechat_HouseServices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseService>(SelectFieldList, "FROM [dbo].[Wechat_HouseService]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_HouseService objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_HouseService objects.</returns>
        public static EntityList<Wechat_HouseService> GetWechat_HouseServices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseService>(SelectFieldList, "FROM [dbo].[Wechat_HouseService]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_HouseService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_HouseService objects.</returns>
		protected static EntityList<Wechat_HouseService> GetWechat_HouseServices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseService objects.</returns>
		protected static EntityList<Wechat_HouseService> GetWechat_HouseServices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServices(string.Empty, where, parameters, Wechat_HouseService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseService objects.</returns>
		protected static EntityList<Wechat_HouseService> GetWechat_HouseServices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServices(prefix, where, parameters, Wechat_HouseService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseService objects.</returns>
		protected static EntityList<Wechat_HouseService> GetWechat_HouseServices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_HouseServices(string.Empty, where, parameters, Wechat_HouseService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseService objects.</returns>
		protected static EntityList<Wechat_HouseService> GetWechat_HouseServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_HouseServices(prefix, where, parameters, Wechat_HouseService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseService objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_HouseService objects.</returns>
		protected static EntityList<Wechat_HouseService> GetWechat_HouseServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_HouseService.SelectFieldList + "FROM [dbo].[Wechat_HouseService] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_HouseService>(reader);
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
        protected static EntityList<Wechat_HouseService> GetWechat_HouseServices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseService>(SelectFieldList, "FROM [dbo].[Wechat_HouseService] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_HouseService objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_HouseServiceCount()
        {
            return GetWechat_HouseServiceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_HouseService objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_HouseServiceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_HouseService] " + where;

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
		public static partial class Wechat_HouseService_Properties
		{
			public const string ID = "ID";
			public const string Title = "Title";
			public const string ContactPhone = "ContactPhone";
			public const string ServiceIncude = "ServiceIncude";
			public const string ServiceStandard = "ServiceStandard";
			public const string AppointNotify = "AppointNotify";
			public const string AddTime = "AddTime";
			public const string CategoryID = "CategoryID";
			public const string IsPublish = "IsPublish";
			public const string IconLink = "IconLink";
			public const string ServiceType = "ServiceType";
			public const string SortOrder = "SortOrder";
			public const string IsWechatShow = "IsWechatShow";
			public const string IsAPPUserShow = "IsAPPUserShow";
			public const string IsAPPCustomerShow = "IsAPPCustomerShow";
			public const string UseOutLink = "UseOutLink";
			public const string OutLinkURL = "OutLinkURL";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Title" , "string:"},
    			 {"ContactPhone" , "string:"},
    			 {"ServiceIncude" , "string:"},
    			 {"ServiceStandard" , "string:"},
    			 {"AppointNotify" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"CategoryID" , "int:"},
    			 {"IsPublish" , "bool:"},
    			 {"IconLink" , "string:"},
    			 {"ServiceType" , "int:1-微信服务 2-APP业主服务"},
    			 {"SortOrder" , "int:"},
    			 {"IsWechatShow" , "bool:"},
    			 {"IsAPPUserShow" , "bool:"},
    			 {"IsAPPCustomerShow" , "bool:"},
    			 {"UseOutLink" , "bool:"},
    			 {"OutLinkURL" , "string:"},
            };
		}
		#endregion
	}
}
