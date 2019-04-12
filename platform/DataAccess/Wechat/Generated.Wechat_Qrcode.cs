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
	/// This object represents the properties and methods of a Wechat_Qrcode.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_Qrcode 
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
		private string _qrCodeURL = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string QrCodeURL
		{
			[DebuggerStepThrough()]
			get { return this._qrCodeURL; }
			set 
			{
				if (this._qrCodeURL != value) 
				{
					this._qrCodeURL = value;
					this.IsDirty = true;	
					OnPropertyChanged("QrCodeURL");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _qrCodeImgPath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string QrCodeImgPath
		{
			[DebuggerStepThrough()]
			get { return this._qrCodeImgPath; }
			set 
			{
				if (this._qrCodeImgPath != value) 
				{
					this._qrCodeImgPath = value;
					this.IsDirty = true;	
					OnPropertyChanged("QrCodeImgPath");
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
	[QrCodeURL] nvarchar(500),
	[QrCodeImgPath] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_Qrcode] (
	[Wechat_Qrcode].[QrCodeURL],
	[Wechat_Qrcode].[QrCodeImgPath],
	[Wechat_Qrcode].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[QrCodeURL],
	INSERTED.[QrCodeImgPath],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@QrCodeURL,
	@QrCodeImgPath,
	@AddTime 
); 

SELECT 
	[ID],
	[QrCodeURL],
	[QrCodeImgPath],
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
	[QrCodeURL] nvarchar(500),
	[QrCodeImgPath] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_Qrcode] SET 
	[Wechat_Qrcode].[QrCodeURL] = @QrCodeURL,
	[Wechat_Qrcode].[QrCodeImgPath] = @QrCodeImgPath,
	[Wechat_Qrcode].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[QrCodeURL],
	INSERTED.[QrCodeImgPath],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_Qrcode].[ID] = @ID

SELECT 
	[ID],
	[QrCodeURL],
	[QrCodeImgPath],
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
DELETE FROM [dbo].[Wechat_Qrcode]
WHERE 
	[Wechat_Qrcode].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_Qrcode() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_Qrcode(this.ID));
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
	[Wechat_Qrcode].[ID],
	[Wechat_Qrcode].[QrCodeURL],
	[Wechat_Qrcode].[QrCodeImgPath],
	[Wechat_Qrcode].[AddTime]
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
                return "Wechat_Qrcode";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_Qrcode into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="qrCodeURL">qrCodeURL</param>
		/// <param name="qrCodeImgPath">qrCodeImgPath</param>
		/// <param name="addTime">addTime</param>
		public static void InsertWechat_Qrcode(string @qrCodeURL, string @qrCodeImgPath, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_Qrcode(@qrCodeURL, @qrCodeImgPath, @addTime, helper);
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
		/// Insert a Wechat_Qrcode into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="qrCodeURL">qrCodeURL</param>
		/// <param name="qrCodeImgPath">qrCodeImgPath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_Qrcode(string @qrCodeURL, string @qrCodeImgPath, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[QrCodeURL] nvarchar(500),
	[QrCodeImgPath] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_Qrcode] (
	[Wechat_Qrcode].[QrCodeURL],
	[Wechat_Qrcode].[QrCodeImgPath],
	[Wechat_Qrcode].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[QrCodeURL],
	INSERTED.[QrCodeImgPath],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@QrCodeURL,
	@QrCodeImgPath,
	@AddTime 
); 

SELECT 
	[ID],
	[QrCodeURL],
	[QrCodeImgPath],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@QrCodeURL", EntityBase.GetDatabaseValue(@qrCodeURL)));
			parameters.Add(new SqlParameter("@QrCodeImgPath", EntityBase.GetDatabaseValue(@qrCodeImgPath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_Qrcode into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="qrCodeURL">qrCodeURL</param>
		/// <param name="qrCodeImgPath">qrCodeImgPath</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateWechat_Qrcode(int @iD, string @qrCodeURL, string @qrCodeImgPath, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_Qrcode(@iD, @qrCodeURL, @qrCodeImgPath, @addTime, helper);
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
		/// Updates a Wechat_Qrcode into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="qrCodeURL">qrCodeURL</param>
		/// <param name="qrCodeImgPath">qrCodeImgPath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_Qrcode(int @iD, string @qrCodeURL, string @qrCodeImgPath, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[QrCodeURL] nvarchar(500),
	[QrCodeImgPath] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_Qrcode] SET 
	[Wechat_Qrcode].[QrCodeURL] = @QrCodeURL,
	[Wechat_Qrcode].[QrCodeImgPath] = @QrCodeImgPath,
	[Wechat_Qrcode].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[QrCodeURL],
	INSERTED.[QrCodeImgPath],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_Qrcode].[ID] = @ID

SELECT 
	[ID],
	[QrCodeURL],
	[QrCodeImgPath],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@QrCodeURL", EntityBase.GetDatabaseValue(@qrCodeURL)));
			parameters.Add(new SqlParameter("@QrCodeImgPath", EntityBase.GetDatabaseValue(@qrCodeImgPath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_Qrcode from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_Qrcode(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_Qrcode(@iD, helper);
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
		/// Deletes a Wechat_Qrcode from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_Qrcode(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_Qrcode]
WHERE 
	[Wechat_Qrcode].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_Qrcode object.
		/// </summary>
		/// <returns>The newly created Wechat_Qrcode object.</returns>
		public static Wechat_Qrcode CreateWechat_Qrcode()
		{
			return InitializeNew<Wechat_Qrcode>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_Qrcode by a Wechat_Qrcode's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_Qrcode</returns>
		public static Wechat_Qrcode GetWechat_Qrcode(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_Qrcode.SelectFieldList + @"
FROM [dbo].[Wechat_Qrcode] 
WHERE 
	[Wechat_Qrcode].[ID] = @ID " + Wechat_Qrcode.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Qrcode>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_Qrcode by a Wechat_Qrcode's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_Qrcode</returns>
		public static Wechat_Qrcode GetWechat_Qrcode(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_Qrcode.SelectFieldList + @"
FROM [dbo].[Wechat_Qrcode] 
WHERE 
	[Wechat_Qrcode].[ID] = @ID " + Wechat_Qrcode.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Qrcode>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Qrcode objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_Qrcode objects.</returns>
		public static EntityList<Wechat_Qrcode> GetWechat_Qrcodes()
		{
			string commandText = @"
SELECT " + Wechat_Qrcode.SelectFieldList + "FROM [dbo].[Wechat_Qrcode] " + Wechat_Qrcode.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_Qrcode>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_Qrcode objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Qrcode objects.</returns>
        public static EntityList<Wechat_Qrcode> GetWechat_Qrcodes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Qrcode>(SelectFieldList, "FROM [dbo].[Wechat_Qrcode]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_Qrcode objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Qrcode objects.</returns>
        public static EntityList<Wechat_Qrcode> GetWechat_Qrcodes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Qrcode>(SelectFieldList, "FROM [dbo].[Wechat_Qrcode]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_Qrcode objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Qrcode objects.</returns>
		protected static EntityList<Wechat_Qrcode> GetWechat_Qrcodes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Qrcodes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Qrcode objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Qrcode objects.</returns>
		protected static EntityList<Wechat_Qrcode> GetWechat_Qrcodes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Qrcodes(string.Empty, where, parameters, Wechat_Qrcode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Qrcode objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Qrcode objects.</returns>
		protected static EntityList<Wechat_Qrcode> GetWechat_Qrcodes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Qrcodes(prefix, where, parameters, Wechat_Qrcode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Qrcode objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Qrcode objects.</returns>
		protected static EntityList<Wechat_Qrcode> GetWechat_Qrcodes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Qrcodes(string.Empty, where, parameters, Wechat_Qrcode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Qrcode objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Qrcode objects.</returns>
		protected static EntityList<Wechat_Qrcode> GetWechat_Qrcodes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Qrcodes(prefix, where, parameters, Wechat_Qrcode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Qrcode objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Qrcode objects.</returns>
		protected static EntityList<Wechat_Qrcode> GetWechat_Qrcodes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_Qrcode.SelectFieldList + "FROM [dbo].[Wechat_Qrcode] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_Qrcode>(reader);
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
        protected static EntityList<Wechat_Qrcode> GetWechat_Qrcodes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Qrcode>(SelectFieldList, "FROM [dbo].[Wechat_Qrcode] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_Qrcode objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_QrcodeCount()
        {
            return GetWechat_QrcodeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_Qrcode objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_QrcodeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_Qrcode] " + where;

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
		public static partial class Wechat_Qrcode_Properties
		{
			public const string ID = "ID";
			public const string QrCodeURL = "QrCodeURL";
			public const string QrCodeImgPath = "QrCodeImgPath";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"QrCodeURL" , "string:"},
    			 {"QrCodeImgPath" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
