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
	/// This object represents the properties and methods of a Wechat_Contact.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_Contact 
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
		private string _phoneType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PhoneType
		{
			[DebuggerStepThrough()]
			get { return this._phoneType; }
			set 
			{
				if (this._phoneType != value) 
				{
					this._phoneType = value;
					this.IsDirty = true;	
					OnPropertyChanged("PhoneType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _phoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._phoneNumber; }
			set 
			{
				if (this._phoneNumber != value) 
				{
					this._phoneNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("PhoneNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Name
		{
			[DebuggerStepThrough()]
			get { return this._name; }
			set 
			{
				if (this._name != value) 
				{
					this._name = value;
					this.IsDirty = true;	
					OnPropertyChanged("Name");
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
	[PhoneType] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[Name] nvarchar(200),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[CategoryID] int
);

INSERT INTO [dbo].[Wechat_Contact] (
	[Wechat_Contact].[PhoneType],
	[Wechat_Contact].[PhoneNumber],
	[Wechat_Contact].[Name],
	[Wechat_Contact].[Remark],
	[Wechat_Contact].[AddMan],
	[Wechat_Contact].[AddTime],
	[Wechat_Contact].[CategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[PhoneType],
	INSERTED.[PhoneNumber],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[CategoryID]
into @table
VALUES ( 
	@PhoneType,
	@PhoneNumber,
	@Name,
	@Remark,
	@AddMan,
	@AddTime,
	@CategoryID 
); 

SELECT 
	[ID],
	[PhoneType],
	[PhoneNumber],
	[Name],
	[Remark],
	[AddMan],
	[AddTime],
	[CategoryID] 
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
	[PhoneType] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[Name] nvarchar(200),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[CategoryID] int
);

UPDATE [dbo].[Wechat_Contact] SET 
	[Wechat_Contact].[PhoneType] = @PhoneType,
	[Wechat_Contact].[PhoneNumber] = @PhoneNumber,
	[Wechat_Contact].[Name] = @Name,
	[Wechat_Contact].[Remark] = @Remark,
	[Wechat_Contact].[AddMan] = @AddMan,
	[Wechat_Contact].[AddTime] = @AddTime,
	[Wechat_Contact].[CategoryID] = @CategoryID 
output 
	INSERTED.[ID],
	INSERTED.[PhoneType],
	INSERTED.[PhoneNumber],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[CategoryID]
into @table
WHERE 
	[Wechat_Contact].[ID] = @ID

SELECT 
	[ID],
	[PhoneType],
	[PhoneNumber],
	[Name],
	[Remark],
	[AddMan],
	[AddTime],
	[CategoryID] 
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
DELETE FROM [dbo].[Wechat_Contact]
WHERE 
	[Wechat_Contact].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_Contact() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_Contact(this.ID));
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
	[Wechat_Contact].[ID],
	[Wechat_Contact].[PhoneType],
	[Wechat_Contact].[PhoneNumber],
	[Wechat_Contact].[Name],
	[Wechat_Contact].[Remark],
	[Wechat_Contact].[AddMan],
	[Wechat_Contact].[AddTime],
	[Wechat_Contact].[CategoryID]
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
                return "Wechat_Contact";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_Contact into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="phoneType">phoneType</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryID">categoryID</param>
		public static void InsertWechat_Contact(string @phoneType, string @phoneNumber, string @name, string @remark, string @addMan, DateTime @addTime, int @categoryID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_Contact(@phoneType, @phoneNumber, @name, @remark, @addMan, @addTime, @categoryID, helper);
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
		/// Insert a Wechat_Contact into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="phoneType">phoneType</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_Contact(string @phoneType, string @phoneNumber, string @name, string @remark, string @addMan, DateTime @addTime, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PhoneType] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[Name] nvarchar(200),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[CategoryID] int
);

INSERT INTO [dbo].[Wechat_Contact] (
	[Wechat_Contact].[PhoneType],
	[Wechat_Contact].[PhoneNumber],
	[Wechat_Contact].[Name],
	[Wechat_Contact].[Remark],
	[Wechat_Contact].[AddMan],
	[Wechat_Contact].[AddTime],
	[Wechat_Contact].[CategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[PhoneType],
	INSERTED.[PhoneNumber],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[CategoryID]
into @table
VALUES ( 
	@PhoneType,
	@PhoneNumber,
	@Name,
	@Remark,
	@AddMan,
	@AddTime,
	@CategoryID 
); 

SELECT 
	[ID],
	[PhoneType],
	[PhoneNumber],
	[Name],
	[Remark],
	[AddMan],
	[AddTime],
	[CategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@PhoneType", EntityBase.GetDatabaseValue(@phoneType)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_Contact into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="phoneType">phoneType</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryID">categoryID</param>
		public static void UpdateWechat_Contact(int @iD, string @phoneType, string @phoneNumber, string @name, string @remark, string @addMan, DateTime @addTime, int @categoryID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_Contact(@iD, @phoneType, @phoneNumber, @name, @remark, @addMan, @addTime, @categoryID, helper);
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
		/// Updates a Wechat_Contact into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="phoneType">phoneType</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_Contact(int @iD, string @phoneType, string @phoneNumber, string @name, string @remark, string @addMan, DateTime @addTime, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PhoneType] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[Name] nvarchar(200),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[CategoryID] int
);

UPDATE [dbo].[Wechat_Contact] SET 
	[Wechat_Contact].[PhoneType] = @PhoneType,
	[Wechat_Contact].[PhoneNumber] = @PhoneNumber,
	[Wechat_Contact].[Name] = @Name,
	[Wechat_Contact].[Remark] = @Remark,
	[Wechat_Contact].[AddMan] = @AddMan,
	[Wechat_Contact].[AddTime] = @AddTime,
	[Wechat_Contact].[CategoryID] = @CategoryID 
output 
	INSERTED.[ID],
	INSERTED.[PhoneType],
	INSERTED.[PhoneNumber],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[CategoryID]
into @table
WHERE 
	[Wechat_Contact].[ID] = @ID

SELECT 
	[ID],
	[PhoneType],
	[PhoneNumber],
	[Name],
	[Remark],
	[AddMan],
	[AddTime],
	[CategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PhoneType", EntityBase.GetDatabaseValue(@phoneType)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_Contact from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_Contact(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_Contact(@iD, helper);
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
		/// Deletes a Wechat_Contact from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_Contact(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_Contact]
WHERE 
	[Wechat_Contact].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_Contact object.
		/// </summary>
		/// <returns>The newly created Wechat_Contact object.</returns>
		public static Wechat_Contact CreateWechat_Contact()
		{
			return InitializeNew<Wechat_Contact>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_Contact by a Wechat_Contact's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_Contact</returns>
		public static Wechat_Contact GetWechat_Contact(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_Contact.SelectFieldList + @"
FROM [dbo].[Wechat_Contact] 
WHERE 
	[Wechat_Contact].[ID] = @ID " + Wechat_Contact.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Contact>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_Contact by a Wechat_Contact's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_Contact</returns>
		public static Wechat_Contact GetWechat_Contact(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_Contact.SelectFieldList + @"
FROM [dbo].[Wechat_Contact] 
WHERE 
	[Wechat_Contact].[ID] = @ID " + Wechat_Contact.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Contact>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Contact objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_Contact objects.</returns>
		public static EntityList<Wechat_Contact> GetWechat_Contacts()
		{
			string commandText = @"
SELECT " + Wechat_Contact.SelectFieldList + "FROM [dbo].[Wechat_Contact] " + Wechat_Contact.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_Contact>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_Contact objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Contact objects.</returns>
        public static EntityList<Wechat_Contact> GetWechat_Contacts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Contact>(SelectFieldList, "FROM [dbo].[Wechat_Contact]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_Contact objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Contact objects.</returns>
        public static EntityList<Wechat_Contact> GetWechat_Contacts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Contact>(SelectFieldList, "FROM [dbo].[Wechat_Contact]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_Contact objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Contact objects.</returns>
		protected static EntityList<Wechat_Contact> GetWechat_Contacts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Contacts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Contact objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Contact objects.</returns>
		protected static EntityList<Wechat_Contact> GetWechat_Contacts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Contacts(string.Empty, where, parameters, Wechat_Contact.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Contact objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Contact objects.</returns>
		protected static EntityList<Wechat_Contact> GetWechat_Contacts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Contacts(prefix, where, parameters, Wechat_Contact.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Contact objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Contact objects.</returns>
		protected static EntityList<Wechat_Contact> GetWechat_Contacts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Contacts(string.Empty, where, parameters, Wechat_Contact.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Contact objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Contact objects.</returns>
		protected static EntityList<Wechat_Contact> GetWechat_Contacts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Contacts(prefix, where, parameters, Wechat_Contact.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Contact objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Contact objects.</returns>
		protected static EntityList<Wechat_Contact> GetWechat_Contacts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_Contact.SelectFieldList + "FROM [dbo].[Wechat_Contact] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_Contact>(reader);
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
        protected static EntityList<Wechat_Contact> GetWechat_Contacts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Contact>(SelectFieldList, "FROM [dbo].[Wechat_Contact] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_Contact objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ContactCount()
        {
            return GetWechat_ContactCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_Contact objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ContactCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_Contact] " + where;

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
		public static partial class Wechat_Contact_Properties
		{
			public const string ID = "ID";
			public const string PhoneType = "PhoneType";
			public const string PhoneNumber = "PhoneNumber";
			public const string Name = "Name";
			public const string Remark = "Remark";
			public const string AddMan = "AddMan";
			public const string AddTime = "AddTime";
			public const string CategoryID = "CategoryID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"PhoneType" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"Name" , "string:"},
    			 {"Remark" , "string:"},
    			 {"AddMan" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"CategoryID" , "int:"},
            };
		}
		#endregion
	}
}
