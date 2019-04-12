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
	/// This object represents the properties and methods of a Wechat_Log.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_Log 
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
		private DateTime _operationTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime OperationTime
		{
			[DebuggerStepThrough()]
			get { return this._operationTime; }
			set 
			{
				if (this._operationTime != value) 
				{
					this._operationTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("OperationTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _operation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Operation
		{
			[DebuggerStepThrough()]
			get { return this._operation; }
			set 
			{
				if (this._operation != value) 
				{
					this._operation = value;
					this.IsDirty = true;	
					OnPropertyChanged("Operation");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _argument1 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Argument1
		{
			[DebuggerStepThrough()]
			get { return this._argument1; }
			set 
			{
				if (this._argument1 != value) 
				{
					this._argument1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Argument1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _argument2 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Argument2
		{
			[DebuggerStepThrough()]
			get { return this._argument2; }
			set 
			{
				if (this._argument2 != value) 
				{
					this._argument2 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Argument2");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _argument3 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Argument3
		{
			[DebuggerStepThrough()]
			get { return this._argument3; }
			set 
			{
				if (this._argument3 != value) 
				{
					this._argument3 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Argument3");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _argument4 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Argument4
		{
			[DebuggerStepThrough()]
			get { return this._argument4; }
			set 
			{
				if (this._argument4 != value) 
				{
					this._argument4 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Argument4");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _argument5 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Argument5
		{
			[DebuggerStepThrough()]
			get { return this._argument5; }
			set 
			{
				if (this._argument5 != value) 
				{
					this._argument5 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Argument5");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _argument6 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Argument6
		{
			[DebuggerStepThrough()]
			get { return this._argument6; }
			set 
			{
				if (this._argument6 != value) 
				{
					this._argument6 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Argument6");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _argument7 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Argument7
		{
			[DebuggerStepThrough()]
			get { return this._argument7; }
			set 
			{
				if (this._argument7 != value) 
				{
					this._argument7 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Argument7");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _argument8 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Argument8
		{
			[DebuggerStepThrough()]
			get { return this._argument8; }
			set 
			{
				if (this._argument8 != value) 
				{
					this._argument8 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Argument8");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _argument9 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Argument9
		{
			[DebuggerStepThrough()]
			get { return this._argument9; }
			set 
			{
				if (this._argument9 != value) 
				{
					this._argument9 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Argument9");
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
	[OpenID] nvarchar(500),
	[OperationTime] datetime,
	[Operation] nvarchar(200),
	[Argument1] nvarchar(500),
	[Argument2] nvarchar(500),
	[Argument3] nvarchar(500),
	[Argument4] nvarchar(500),
	[Argument5] nvarchar(500),
	[Argument6] nvarchar(500),
	[Argument7] nvarchar(500),
	[Argument8] nvarchar(500),
	[Argument9] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_Log] (
	[Wechat_Log].[OpenID],
	[Wechat_Log].[OperationTime],
	[Wechat_Log].[Operation],
	[Wechat_Log].[Argument1],
	[Wechat_Log].[Argument2],
	[Wechat_Log].[Argument3],
	[Wechat_Log].[Argument4],
	[Wechat_Log].[Argument5],
	[Wechat_Log].[Argument6],
	[Wechat_Log].[Argument7],
	[Wechat_Log].[Argument8],
	[Wechat_Log].[Argument9]
) 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[OperationTime],
	INSERTED.[Operation],
	INSERTED.[Argument1],
	INSERTED.[Argument2],
	INSERTED.[Argument3],
	INSERTED.[Argument4],
	INSERTED.[Argument5],
	INSERTED.[Argument6],
	INSERTED.[Argument7],
	INSERTED.[Argument8],
	INSERTED.[Argument9]
into @table
VALUES ( 
	@OpenID,
	@OperationTime,
	@Operation,
	@Argument1,
	@Argument2,
	@Argument3,
	@Argument4,
	@Argument5,
	@Argument6,
	@Argument7,
	@Argument8,
	@Argument9 
); 

SELECT 
	[ID],
	[OpenID],
	[OperationTime],
	[Operation],
	[Argument1],
	[Argument2],
	[Argument3],
	[Argument4],
	[Argument5],
	[Argument6],
	[Argument7],
	[Argument8],
	[Argument9] 
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
	[OpenID] nvarchar(500),
	[OperationTime] datetime,
	[Operation] nvarchar(200),
	[Argument1] nvarchar(500),
	[Argument2] nvarchar(500),
	[Argument3] nvarchar(500),
	[Argument4] nvarchar(500),
	[Argument5] nvarchar(500),
	[Argument6] nvarchar(500),
	[Argument7] nvarchar(500),
	[Argument8] nvarchar(500),
	[Argument9] nvarchar(500)
);

UPDATE [dbo].[Wechat_Log] SET 
	[Wechat_Log].[OpenID] = @OpenID,
	[Wechat_Log].[OperationTime] = @OperationTime,
	[Wechat_Log].[Operation] = @Operation,
	[Wechat_Log].[Argument1] = @Argument1,
	[Wechat_Log].[Argument2] = @Argument2,
	[Wechat_Log].[Argument3] = @Argument3,
	[Wechat_Log].[Argument4] = @Argument4,
	[Wechat_Log].[Argument5] = @Argument5,
	[Wechat_Log].[Argument6] = @Argument6,
	[Wechat_Log].[Argument7] = @Argument7,
	[Wechat_Log].[Argument8] = @Argument8,
	[Wechat_Log].[Argument9] = @Argument9 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[OperationTime],
	INSERTED.[Operation],
	INSERTED.[Argument1],
	INSERTED.[Argument2],
	INSERTED.[Argument3],
	INSERTED.[Argument4],
	INSERTED.[Argument5],
	INSERTED.[Argument6],
	INSERTED.[Argument7],
	INSERTED.[Argument8],
	INSERTED.[Argument9]
into @table
WHERE 
	[Wechat_Log].[ID] = @ID

SELECT 
	[ID],
	[OpenID],
	[OperationTime],
	[Operation],
	[Argument1],
	[Argument2],
	[Argument3],
	[Argument4],
	[Argument5],
	[Argument6],
	[Argument7],
	[Argument8],
	[Argument9] 
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
DELETE FROM [dbo].[Wechat_Log]
WHERE 
	[Wechat_Log].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_Log() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_Log(this.ID));
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
	[Wechat_Log].[ID],
	[Wechat_Log].[OpenID],
	[Wechat_Log].[OperationTime],
	[Wechat_Log].[Operation],
	[Wechat_Log].[Argument1],
	[Wechat_Log].[Argument2],
	[Wechat_Log].[Argument3],
	[Wechat_Log].[Argument4],
	[Wechat_Log].[Argument5],
	[Wechat_Log].[Argument6],
	[Wechat_Log].[Argument7],
	[Wechat_Log].[Argument8],
	[Wechat_Log].[Argument9]
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
                return "Wechat_Log";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_Log into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="openID">openID</param>
		/// <param name="operationTime">operationTime</param>
		/// <param name="operation">operation</param>
		/// <param name="argument1">argument1</param>
		/// <param name="argument2">argument2</param>
		/// <param name="argument3">argument3</param>
		/// <param name="argument4">argument4</param>
		/// <param name="argument5">argument5</param>
		/// <param name="argument6">argument6</param>
		/// <param name="argument7">argument7</param>
		/// <param name="argument8">argument8</param>
		/// <param name="argument9">argument9</param>
		public static void InsertWechat_Log(string @openID, DateTime @operationTime, string @operation, string @argument1, string @argument2, string @argument3, string @argument4, string @argument5, string @argument6, string @argument7, string @argument8, string @argument9)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_Log(@openID, @operationTime, @operation, @argument1, @argument2, @argument3, @argument4, @argument5, @argument6, @argument7, @argument8, @argument9, helper);
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
		/// Insert a Wechat_Log into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="openID">openID</param>
		/// <param name="operationTime">operationTime</param>
		/// <param name="operation">operation</param>
		/// <param name="argument1">argument1</param>
		/// <param name="argument2">argument2</param>
		/// <param name="argument3">argument3</param>
		/// <param name="argument4">argument4</param>
		/// <param name="argument5">argument5</param>
		/// <param name="argument6">argument6</param>
		/// <param name="argument7">argument7</param>
		/// <param name="argument8">argument8</param>
		/// <param name="argument9">argument9</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_Log(string @openID, DateTime @operationTime, string @operation, string @argument1, string @argument2, string @argument3, string @argument4, string @argument5, string @argument6, string @argument7, string @argument8, string @argument9, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OpenID] nvarchar(500),
	[OperationTime] datetime,
	[Operation] nvarchar(200),
	[Argument1] nvarchar(500),
	[Argument2] nvarchar(500),
	[Argument3] nvarchar(500),
	[Argument4] nvarchar(500),
	[Argument5] nvarchar(500),
	[Argument6] nvarchar(500),
	[Argument7] nvarchar(500),
	[Argument8] nvarchar(500),
	[Argument9] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_Log] (
	[Wechat_Log].[OpenID],
	[Wechat_Log].[OperationTime],
	[Wechat_Log].[Operation],
	[Wechat_Log].[Argument1],
	[Wechat_Log].[Argument2],
	[Wechat_Log].[Argument3],
	[Wechat_Log].[Argument4],
	[Wechat_Log].[Argument5],
	[Wechat_Log].[Argument6],
	[Wechat_Log].[Argument7],
	[Wechat_Log].[Argument8],
	[Wechat_Log].[Argument9]
) 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[OperationTime],
	INSERTED.[Operation],
	INSERTED.[Argument1],
	INSERTED.[Argument2],
	INSERTED.[Argument3],
	INSERTED.[Argument4],
	INSERTED.[Argument5],
	INSERTED.[Argument6],
	INSERTED.[Argument7],
	INSERTED.[Argument8],
	INSERTED.[Argument9]
into @table
VALUES ( 
	@OpenID,
	@OperationTime,
	@Operation,
	@Argument1,
	@Argument2,
	@Argument3,
	@Argument4,
	@Argument5,
	@Argument6,
	@Argument7,
	@Argument8,
	@Argument9 
); 

SELECT 
	[ID],
	[OpenID],
	[OperationTime],
	[Operation],
	[Argument1],
	[Argument2],
	[Argument3],
	[Argument4],
	[Argument5],
	[Argument6],
	[Argument7],
	[Argument8],
	[Argument9] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@OperationTime", EntityBase.GetDatabaseValue(@operationTime)));
			parameters.Add(new SqlParameter("@Operation", EntityBase.GetDatabaseValue(@operation)));
			parameters.Add(new SqlParameter("@Argument1", EntityBase.GetDatabaseValue(@argument1)));
			parameters.Add(new SqlParameter("@Argument2", EntityBase.GetDatabaseValue(@argument2)));
			parameters.Add(new SqlParameter("@Argument3", EntityBase.GetDatabaseValue(@argument3)));
			parameters.Add(new SqlParameter("@Argument4", EntityBase.GetDatabaseValue(@argument4)));
			parameters.Add(new SqlParameter("@Argument5", EntityBase.GetDatabaseValue(@argument5)));
			parameters.Add(new SqlParameter("@Argument6", EntityBase.GetDatabaseValue(@argument6)));
			parameters.Add(new SqlParameter("@Argument7", EntityBase.GetDatabaseValue(@argument7)));
			parameters.Add(new SqlParameter("@Argument8", EntityBase.GetDatabaseValue(@argument8)));
			parameters.Add(new SqlParameter("@Argument9", EntityBase.GetDatabaseValue(@argument9)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_Log into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="openID">openID</param>
		/// <param name="operationTime">operationTime</param>
		/// <param name="operation">operation</param>
		/// <param name="argument1">argument1</param>
		/// <param name="argument2">argument2</param>
		/// <param name="argument3">argument3</param>
		/// <param name="argument4">argument4</param>
		/// <param name="argument5">argument5</param>
		/// <param name="argument6">argument6</param>
		/// <param name="argument7">argument7</param>
		/// <param name="argument8">argument8</param>
		/// <param name="argument9">argument9</param>
		public static void UpdateWechat_Log(int @iD, string @openID, DateTime @operationTime, string @operation, string @argument1, string @argument2, string @argument3, string @argument4, string @argument5, string @argument6, string @argument7, string @argument8, string @argument9)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_Log(@iD, @openID, @operationTime, @operation, @argument1, @argument2, @argument3, @argument4, @argument5, @argument6, @argument7, @argument8, @argument9, helper);
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
		/// Updates a Wechat_Log into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="openID">openID</param>
		/// <param name="operationTime">operationTime</param>
		/// <param name="operation">operation</param>
		/// <param name="argument1">argument1</param>
		/// <param name="argument2">argument2</param>
		/// <param name="argument3">argument3</param>
		/// <param name="argument4">argument4</param>
		/// <param name="argument5">argument5</param>
		/// <param name="argument6">argument6</param>
		/// <param name="argument7">argument7</param>
		/// <param name="argument8">argument8</param>
		/// <param name="argument9">argument9</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_Log(int @iD, string @openID, DateTime @operationTime, string @operation, string @argument1, string @argument2, string @argument3, string @argument4, string @argument5, string @argument6, string @argument7, string @argument8, string @argument9, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OpenID] nvarchar(500),
	[OperationTime] datetime,
	[Operation] nvarchar(200),
	[Argument1] nvarchar(500),
	[Argument2] nvarchar(500),
	[Argument3] nvarchar(500),
	[Argument4] nvarchar(500),
	[Argument5] nvarchar(500),
	[Argument6] nvarchar(500),
	[Argument7] nvarchar(500),
	[Argument8] nvarchar(500),
	[Argument9] nvarchar(500)
);

UPDATE [dbo].[Wechat_Log] SET 
	[Wechat_Log].[OpenID] = @OpenID,
	[Wechat_Log].[OperationTime] = @OperationTime,
	[Wechat_Log].[Operation] = @Operation,
	[Wechat_Log].[Argument1] = @Argument1,
	[Wechat_Log].[Argument2] = @Argument2,
	[Wechat_Log].[Argument3] = @Argument3,
	[Wechat_Log].[Argument4] = @Argument4,
	[Wechat_Log].[Argument5] = @Argument5,
	[Wechat_Log].[Argument6] = @Argument6,
	[Wechat_Log].[Argument7] = @Argument7,
	[Wechat_Log].[Argument8] = @Argument8,
	[Wechat_Log].[Argument9] = @Argument9 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[OperationTime],
	INSERTED.[Operation],
	INSERTED.[Argument1],
	INSERTED.[Argument2],
	INSERTED.[Argument3],
	INSERTED.[Argument4],
	INSERTED.[Argument5],
	INSERTED.[Argument6],
	INSERTED.[Argument7],
	INSERTED.[Argument8],
	INSERTED.[Argument9]
into @table
WHERE 
	[Wechat_Log].[ID] = @ID

SELECT 
	[ID],
	[OpenID],
	[OperationTime],
	[Operation],
	[Argument1],
	[Argument2],
	[Argument3],
	[Argument4],
	[Argument5],
	[Argument6],
	[Argument7],
	[Argument8],
	[Argument9] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@OperationTime", EntityBase.GetDatabaseValue(@operationTime)));
			parameters.Add(new SqlParameter("@Operation", EntityBase.GetDatabaseValue(@operation)));
			parameters.Add(new SqlParameter("@Argument1", EntityBase.GetDatabaseValue(@argument1)));
			parameters.Add(new SqlParameter("@Argument2", EntityBase.GetDatabaseValue(@argument2)));
			parameters.Add(new SqlParameter("@Argument3", EntityBase.GetDatabaseValue(@argument3)));
			parameters.Add(new SqlParameter("@Argument4", EntityBase.GetDatabaseValue(@argument4)));
			parameters.Add(new SqlParameter("@Argument5", EntityBase.GetDatabaseValue(@argument5)));
			parameters.Add(new SqlParameter("@Argument6", EntityBase.GetDatabaseValue(@argument6)));
			parameters.Add(new SqlParameter("@Argument7", EntityBase.GetDatabaseValue(@argument7)));
			parameters.Add(new SqlParameter("@Argument8", EntityBase.GetDatabaseValue(@argument8)));
			parameters.Add(new SqlParameter("@Argument9", EntityBase.GetDatabaseValue(@argument9)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_Log from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_Log(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_Log(@iD, helper);
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
		/// Deletes a Wechat_Log from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_Log(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_Log]
WHERE 
	[Wechat_Log].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_Log object.
		/// </summary>
		/// <returns>The newly created Wechat_Log object.</returns>
		public static Wechat_Log CreateWechat_Log()
		{
			return InitializeNew<Wechat_Log>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_Log by a Wechat_Log's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_Log</returns>
		public static Wechat_Log GetWechat_Log(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_Log.SelectFieldList + @"
FROM [dbo].[Wechat_Log] 
WHERE 
	[Wechat_Log].[ID] = @ID " + Wechat_Log.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Log>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_Log by a Wechat_Log's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_Log</returns>
		public static Wechat_Log GetWechat_Log(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_Log.SelectFieldList + @"
FROM [dbo].[Wechat_Log] 
WHERE 
	[Wechat_Log].[ID] = @ID " + Wechat_Log.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Log>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Log objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_Log objects.</returns>
		public static EntityList<Wechat_Log> GetWechat_Logs()
		{
			string commandText = @"
SELECT " + Wechat_Log.SelectFieldList + "FROM [dbo].[Wechat_Log] " + Wechat_Log.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_Log>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_Log objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Log objects.</returns>
        public static EntityList<Wechat_Log> GetWechat_Logs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Log>(SelectFieldList, "FROM [dbo].[Wechat_Log]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_Log objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Log objects.</returns>
        public static EntityList<Wechat_Log> GetWechat_Logs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Log>(SelectFieldList, "FROM [dbo].[Wechat_Log]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_Log objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Log objects.</returns>
		protected static EntityList<Wechat_Log> GetWechat_Logs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Logs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Log objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Log objects.</returns>
		protected static EntityList<Wechat_Log> GetWechat_Logs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Logs(string.Empty, where, parameters, Wechat_Log.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Log objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Log objects.</returns>
		protected static EntityList<Wechat_Log> GetWechat_Logs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Logs(prefix, where, parameters, Wechat_Log.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Log objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Log objects.</returns>
		protected static EntityList<Wechat_Log> GetWechat_Logs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Logs(string.Empty, where, parameters, Wechat_Log.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Log objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Log objects.</returns>
		protected static EntityList<Wechat_Log> GetWechat_Logs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Logs(prefix, where, parameters, Wechat_Log.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Log objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Log objects.</returns>
		protected static EntityList<Wechat_Log> GetWechat_Logs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_Log.SelectFieldList + "FROM [dbo].[Wechat_Log] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_Log>(reader);
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
        protected static EntityList<Wechat_Log> GetWechat_Logs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Log>(SelectFieldList, "FROM [dbo].[Wechat_Log] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_Log objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LogCount()
        {
            return GetWechat_LogCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_Log objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LogCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_Log] " + where;

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
		public static partial class Wechat_Log_Properties
		{
			public const string ID = "ID";
			public const string OpenID = "OpenID";
			public const string OperationTime = "OperationTime";
			public const string Operation = "Operation";
			public const string Argument1 = "Argument1";
			public const string Argument2 = "Argument2";
			public const string Argument3 = "Argument3";
			public const string Argument4 = "Argument4";
			public const string Argument5 = "Argument5";
			public const string Argument6 = "Argument6";
			public const string Argument7 = "Argument7";
			public const string Argument8 = "Argument8";
			public const string Argument9 = "Argument9";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OpenID" , "string:"},
    			 {"OperationTime" , "DateTime:"},
    			 {"Operation" , "string:"},
    			 {"Argument1" , "string:"},
    			 {"Argument2" , "string:"},
    			 {"Argument3" , "string:"},
    			 {"Argument4" , "string:"},
    			 {"Argument5" , "string:"},
    			 {"Argument6" , "string:"},
    			 {"Argument7" , "string:"},
    			 {"Argument8" , "string:"},
    			 {"Argument9" , "string:"},
            };
		}
		#endregion
	}
}
