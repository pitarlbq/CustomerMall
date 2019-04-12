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
	/// This object represents the properties and methods of a Mall_Business_Picture.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Business_Picture 
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
		private int _businessID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int BusinessID
		{
			[DebuggerStepThrough()]
			get { return this._businessID; }
			set 
			{
				if (this._businessID != value) 
				{
					this._businessID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _iconPicPath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string IconPicPath
		{
			[DebuggerStepThrough()]
			get { return this._iconPicPath; }
			set 
			{
				if (this._iconPicPath != value) 
				{
					this._iconPicPath = value;
					this.IsDirty = true;	
					OnPropertyChanged("IconPicPath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _mediumPicPath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string MediumPicPath
		{
			[DebuggerStepThrough()]
			get { return this._mediumPicPath; }
			set 
			{
				if (this._mediumPicPath != value) 
				{
					this._mediumPicPath = value;
					this.IsDirty = true;	
					OnPropertyChanged("MediumPicPath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _largePicPath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string LargePicPath
		{
			[DebuggerStepThrough()]
			get { return this._largePicPath; }
			set 
			{
				if (this._largePicPath != value) 
				{
					this._largePicPath = value;
					this.IsDirty = true;	
					OnPropertyChanged("LargePicPath");
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
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
	[BusinessID] int,
	[IconPicPath] nvarchar(500),
	[MediumPicPath] nvarchar(500),
	[LargePicPath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

INSERT INTO [dbo].[Mall_Business_Picture] (
	[Mall_Business_Picture].[BusinessID],
	[Mall_Business_Picture].[IconPicPath],
	[Mall_Business_Picture].[MediumPicPath],
	[Mall_Business_Picture].[LargePicPath],
	[Mall_Business_Picture].[AddTime],
	[Mall_Business_Picture].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[IconPicPath],
	INSERTED.[MediumPicPath],
	INSERTED.[LargePicPath],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@BusinessID,
	@IconPicPath,
	@MediumPicPath,
	@LargePicPath,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[BusinessID],
	[IconPicPath],
	[MediumPicPath],
	[LargePicPath],
	[AddTime],
	[AddMan] 
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
	[BusinessID] int,
	[IconPicPath] nvarchar(500),
	[MediumPicPath] nvarchar(500),
	[LargePicPath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

UPDATE [dbo].[Mall_Business_Picture] SET 
	[Mall_Business_Picture].[BusinessID] = @BusinessID,
	[Mall_Business_Picture].[IconPicPath] = @IconPicPath,
	[Mall_Business_Picture].[MediumPicPath] = @MediumPicPath,
	[Mall_Business_Picture].[LargePicPath] = @LargePicPath,
	[Mall_Business_Picture].[AddTime] = @AddTime,
	[Mall_Business_Picture].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[IconPicPath],
	INSERTED.[MediumPicPath],
	INSERTED.[LargePicPath],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[Mall_Business_Picture].[ID] = @ID

SELECT 
	[ID],
	[BusinessID],
	[IconPicPath],
	[MediumPicPath],
	[LargePicPath],
	[AddTime],
	[AddMan] 
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
DELETE FROM [dbo].[Mall_Business_Picture]
WHERE 
	[Mall_Business_Picture].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Business_Picture() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Business_Picture(this.ID));
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
	[Mall_Business_Picture].[ID],
	[Mall_Business_Picture].[BusinessID],
	[Mall_Business_Picture].[IconPicPath],
	[Mall_Business_Picture].[MediumPicPath],
	[Mall_Business_Picture].[LargePicPath],
	[Mall_Business_Picture].[AddTime],
	[Mall_Business_Picture].[AddMan]
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
                return "Mall_Business_Picture";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Business_Picture into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessID">businessID</param>
		/// <param name="iconPicPath">iconPicPath</param>
		/// <param name="mediumPicPath">mediumPicPath</param>
		/// <param name="largePicPath">largePicPath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void InsertMall_Business_Picture(int @businessID, string @iconPicPath, string @mediumPicPath, string @largePicPath, DateTime @addTime, string @addMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Business_Picture(@businessID, @iconPicPath, @mediumPicPath, @largePicPath, @addTime, @addMan, helper);
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
		/// Insert a Mall_Business_Picture into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessID">businessID</param>
		/// <param name="iconPicPath">iconPicPath</param>
		/// <param name="mediumPicPath">mediumPicPath</param>
		/// <param name="largePicPath">largePicPath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Business_Picture(int @businessID, string @iconPicPath, string @mediumPicPath, string @largePicPath, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessID] int,
	[IconPicPath] nvarchar(500),
	[MediumPicPath] nvarchar(500),
	[LargePicPath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

INSERT INTO [dbo].[Mall_Business_Picture] (
	[Mall_Business_Picture].[BusinessID],
	[Mall_Business_Picture].[IconPicPath],
	[Mall_Business_Picture].[MediumPicPath],
	[Mall_Business_Picture].[LargePicPath],
	[Mall_Business_Picture].[AddTime],
	[Mall_Business_Picture].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[IconPicPath],
	INSERTED.[MediumPicPath],
	INSERTED.[LargePicPath],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@BusinessID,
	@IconPicPath,
	@MediumPicPath,
	@LargePicPath,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[BusinessID],
	[IconPicPath],
	[MediumPicPath],
	[LargePicPath],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@IconPicPath", EntityBase.GetDatabaseValue(@iconPicPath)));
			parameters.Add(new SqlParameter("@MediumPicPath", EntityBase.GetDatabaseValue(@mediumPicPath)));
			parameters.Add(new SqlParameter("@LargePicPath", EntityBase.GetDatabaseValue(@largePicPath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Business_Picture into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessID">businessID</param>
		/// <param name="iconPicPath">iconPicPath</param>
		/// <param name="mediumPicPath">mediumPicPath</param>
		/// <param name="largePicPath">largePicPath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void UpdateMall_Business_Picture(int @iD, int @businessID, string @iconPicPath, string @mediumPicPath, string @largePicPath, DateTime @addTime, string @addMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Business_Picture(@iD, @businessID, @iconPicPath, @mediumPicPath, @largePicPath, @addTime, @addMan, helper);
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
		/// Updates a Mall_Business_Picture into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessID">businessID</param>
		/// <param name="iconPicPath">iconPicPath</param>
		/// <param name="mediumPicPath">mediumPicPath</param>
		/// <param name="largePicPath">largePicPath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Business_Picture(int @iD, int @businessID, string @iconPicPath, string @mediumPicPath, string @largePicPath, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessID] int,
	[IconPicPath] nvarchar(500),
	[MediumPicPath] nvarchar(500),
	[LargePicPath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

UPDATE [dbo].[Mall_Business_Picture] SET 
	[Mall_Business_Picture].[BusinessID] = @BusinessID,
	[Mall_Business_Picture].[IconPicPath] = @IconPicPath,
	[Mall_Business_Picture].[MediumPicPath] = @MediumPicPath,
	[Mall_Business_Picture].[LargePicPath] = @LargePicPath,
	[Mall_Business_Picture].[AddTime] = @AddTime,
	[Mall_Business_Picture].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[IconPicPath],
	INSERTED.[MediumPicPath],
	INSERTED.[LargePicPath],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[Mall_Business_Picture].[ID] = @ID

SELECT 
	[ID],
	[BusinessID],
	[IconPicPath],
	[MediumPicPath],
	[LargePicPath],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@IconPicPath", EntityBase.GetDatabaseValue(@iconPicPath)));
			parameters.Add(new SqlParameter("@MediumPicPath", EntityBase.GetDatabaseValue(@mediumPicPath)));
			parameters.Add(new SqlParameter("@LargePicPath", EntityBase.GetDatabaseValue(@largePicPath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Business_Picture from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Business_Picture(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Business_Picture(@iD, helper);
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
		/// Deletes a Mall_Business_Picture from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Business_Picture(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Business_Picture]
WHERE 
	[Mall_Business_Picture].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Business_Picture object.
		/// </summary>
		/// <returns>The newly created Mall_Business_Picture object.</returns>
		public static Mall_Business_Picture CreateMall_Business_Picture()
		{
			return InitializeNew<Mall_Business_Picture>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Business_Picture by a Mall_Business_Picture's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Business_Picture</returns>
		public static Mall_Business_Picture GetMall_Business_Picture(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Business_Picture.SelectFieldList + @"
FROM [dbo].[Mall_Business_Picture] 
WHERE 
	[Mall_Business_Picture].[ID] = @ID " + Mall_Business_Picture.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Business_Picture>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Business_Picture by a Mall_Business_Picture's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Business_Picture</returns>
		public static Mall_Business_Picture GetMall_Business_Picture(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Business_Picture.SelectFieldList + @"
FROM [dbo].[Mall_Business_Picture] 
WHERE 
	[Mall_Business_Picture].[ID] = @ID " + Mall_Business_Picture.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Business_Picture>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business_Picture objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Business_Picture objects.</returns>
		public static EntityList<Mall_Business_Picture> GetMall_Business_Pictures()
		{
			string commandText = @"
SELECT " + Mall_Business_Picture.SelectFieldList + "FROM [dbo].[Mall_Business_Picture] " + Mall_Business_Picture.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Business_Picture>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Business_Picture objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Business_Picture objects.</returns>
        public static EntityList<Mall_Business_Picture> GetMall_Business_Pictures(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Business_Picture>(SelectFieldList, "FROM [dbo].[Mall_Business_Picture]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Business_Picture objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Business_Picture objects.</returns>
        public static EntityList<Mall_Business_Picture> GetMall_Business_Pictures(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Business_Picture>(SelectFieldList, "FROM [dbo].[Mall_Business_Picture]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Business_Picture objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Business_Picture objects.</returns>
		protected static EntityList<Mall_Business_Picture> GetMall_Business_Pictures(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Business_Pictures(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business_Picture objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Business_Picture objects.</returns>
		protected static EntityList<Mall_Business_Picture> GetMall_Business_Pictures(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Business_Pictures(string.Empty, where, parameters, Mall_Business_Picture.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business_Picture objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Business_Picture objects.</returns>
		protected static EntityList<Mall_Business_Picture> GetMall_Business_Pictures(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Business_Pictures(prefix, where, parameters, Mall_Business_Picture.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business_Picture objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Business_Picture objects.</returns>
		protected static EntityList<Mall_Business_Picture> GetMall_Business_Pictures(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Business_Pictures(string.Empty, where, parameters, Mall_Business_Picture.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business_Picture objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Business_Picture objects.</returns>
		protected static EntityList<Mall_Business_Picture> GetMall_Business_Pictures(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Business_Pictures(prefix, where, parameters, Mall_Business_Picture.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business_Picture objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Business_Picture objects.</returns>
		protected static EntityList<Mall_Business_Picture> GetMall_Business_Pictures(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Business_Picture.SelectFieldList + "FROM [dbo].[Mall_Business_Picture] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Business_Picture>(reader);
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
        protected static EntityList<Mall_Business_Picture> GetMall_Business_Pictures(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Business_Picture>(SelectFieldList, "FROM [dbo].[Mall_Business_Picture] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Business_Picture objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_Business_PictureCount()
        {
            return GetMall_Business_PictureCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Business_Picture objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_Business_PictureCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Business_Picture] " + where;

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
		public static partial class Mall_Business_Picture_Properties
		{
			public const string ID = "ID";
			public const string BusinessID = "BusinessID";
			public const string IconPicPath = "IconPicPath";
			public const string MediumPicPath = "MediumPicPath";
			public const string LargePicPath = "LargePicPath";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BusinessID" , "int:"},
    			 {"IconPicPath" , "string:"},
    			 {"MediumPicPath" , "string:"},
    			 {"LargePicPath" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
            };
		}
		#endregion
	}
}
