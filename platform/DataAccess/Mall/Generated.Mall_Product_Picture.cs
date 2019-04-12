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
	/// This object represents the properties and methods of a Mall_Product_Picture.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Product_Picture 
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
		private int _productID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProductID
		{
			[DebuggerStepThrough()]
			get { return this._productID; }
			set 
			{
				if (this._productID != value) 
				{
					this._productID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductID");
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
	[ProductID] int,
	[IconPicPath] nvarchar(500),
	[MediumPicPath] nvarchar(500),
	[LargePicPath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

INSERT INTO [dbo].[Mall_Product_Picture] (
	[Mall_Product_Picture].[ProductID],
	[Mall_Product_Picture].[IconPicPath],
	[Mall_Product_Picture].[MediumPicPath],
	[Mall_Product_Picture].[LargePicPath],
	[Mall_Product_Picture].[AddTime],
	[Mall_Product_Picture].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[IconPicPath],
	INSERTED.[MediumPicPath],
	INSERTED.[LargePicPath],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@ProductID,
	@IconPicPath,
	@MediumPicPath,
	@LargePicPath,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[ProductID],
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
	[ProductID] int,
	[IconPicPath] nvarchar(500),
	[MediumPicPath] nvarchar(500),
	[LargePicPath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

UPDATE [dbo].[Mall_Product_Picture] SET 
	[Mall_Product_Picture].[ProductID] = @ProductID,
	[Mall_Product_Picture].[IconPicPath] = @IconPicPath,
	[Mall_Product_Picture].[MediumPicPath] = @MediumPicPath,
	[Mall_Product_Picture].[LargePicPath] = @LargePicPath,
	[Mall_Product_Picture].[AddTime] = @AddTime,
	[Mall_Product_Picture].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[IconPicPath],
	INSERTED.[MediumPicPath],
	INSERTED.[LargePicPath],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[Mall_Product_Picture].[ID] = @ID

SELECT 
	[ID],
	[ProductID],
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
DELETE FROM [dbo].[Mall_Product_Picture]
WHERE 
	[Mall_Product_Picture].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Product_Picture() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Product_Picture(this.ID));
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
	[Mall_Product_Picture].[ID],
	[Mall_Product_Picture].[ProductID],
	[Mall_Product_Picture].[IconPicPath],
	[Mall_Product_Picture].[MediumPicPath],
	[Mall_Product_Picture].[LargePicPath],
	[Mall_Product_Picture].[AddTime],
	[Mall_Product_Picture].[AddMan]
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
                return "Mall_Product_Picture";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Product_Picture into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="iconPicPath">iconPicPath</param>
		/// <param name="mediumPicPath">mediumPicPath</param>
		/// <param name="largePicPath">largePicPath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void InsertMall_Product_Picture(int @productID, string @iconPicPath, string @mediumPicPath, string @largePicPath, DateTime @addTime, string @addMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Product_Picture(@productID, @iconPicPath, @mediumPicPath, @largePicPath, @addTime, @addMan, helper);
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
		/// Insert a Mall_Product_Picture into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="iconPicPath">iconPicPath</param>
		/// <param name="mediumPicPath">mediumPicPath</param>
		/// <param name="largePicPath">largePicPath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Product_Picture(int @productID, string @iconPicPath, string @mediumPicPath, string @largePicPath, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductID] int,
	[IconPicPath] nvarchar(500),
	[MediumPicPath] nvarchar(500),
	[LargePicPath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

INSERT INTO [dbo].[Mall_Product_Picture] (
	[Mall_Product_Picture].[ProductID],
	[Mall_Product_Picture].[IconPicPath],
	[Mall_Product_Picture].[MediumPicPath],
	[Mall_Product_Picture].[LargePicPath],
	[Mall_Product_Picture].[AddTime],
	[Mall_Product_Picture].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[IconPicPath],
	INSERTED.[MediumPicPath],
	INSERTED.[LargePicPath],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@ProductID,
	@IconPicPath,
	@MediumPicPath,
	@LargePicPath,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[ProductID],
	[IconPicPath],
	[MediumPicPath],
	[LargePicPath],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@IconPicPath", EntityBase.GetDatabaseValue(@iconPicPath)));
			parameters.Add(new SqlParameter("@MediumPicPath", EntityBase.GetDatabaseValue(@mediumPicPath)));
			parameters.Add(new SqlParameter("@LargePicPath", EntityBase.GetDatabaseValue(@largePicPath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Product_Picture into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productID">productID</param>
		/// <param name="iconPicPath">iconPicPath</param>
		/// <param name="mediumPicPath">mediumPicPath</param>
		/// <param name="largePicPath">largePicPath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void UpdateMall_Product_Picture(int @iD, int @productID, string @iconPicPath, string @mediumPicPath, string @largePicPath, DateTime @addTime, string @addMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Product_Picture(@iD, @productID, @iconPicPath, @mediumPicPath, @largePicPath, @addTime, @addMan, helper);
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
		/// Updates a Mall_Product_Picture into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productID">productID</param>
		/// <param name="iconPicPath">iconPicPath</param>
		/// <param name="mediumPicPath">mediumPicPath</param>
		/// <param name="largePicPath">largePicPath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Product_Picture(int @iD, int @productID, string @iconPicPath, string @mediumPicPath, string @largePicPath, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductID] int,
	[IconPicPath] nvarchar(500),
	[MediumPicPath] nvarchar(500),
	[LargePicPath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

UPDATE [dbo].[Mall_Product_Picture] SET 
	[Mall_Product_Picture].[ProductID] = @ProductID,
	[Mall_Product_Picture].[IconPicPath] = @IconPicPath,
	[Mall_Product_Picture].[MediumPicPath] = @MediumPicPath,
	[Mall_Product_Picture].[LargePicPath] = @LargePicPath,
	[Mall_Product_Picture].[AddTime] = @AddTime,
	[Mall_Product_Picture].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[IconPicPath],
	INSERTED.[MediumPicPath],
	INSERTED.[LargePicPath],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[Mall_Product_Picture].[ID] = @ID

SELECT 
	[ID],
	[ProductID],
	[IconPicPath],
	[MediumPicPath],
	[LargePicPath],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@IconPicPath", EntityBase.GetDatabaseValue(@iconPicPath)));
			parameters.Add(new SqlParameter("@MediumPicPath", EntityBase.GetDatabaseValue(@mediumPicPath)));
			parameters.Add(new SqlParameter("@LargePicPath", EntityBase.GetDatabaseValue(@largePicPath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Product_Picture from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Product_Picture(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Product_Picture(@iD, helper);
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
		/// Deletes a Mall_Product_Picture from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Product_Picture(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Product_Picture]
WHERE 
	[Mall_Product_Picture].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Product_Picture object.
		/// </summary>
		/// <returns>The newly created Mall_Product_Picture object.</returns>
		public static Mall_Product_Picture CreateMall_Product_Picture()
		{
			return InitializeNew<Mall_Product_Picture>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Product_Picture by a Mall_Product_Picture's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Product_Picture</returns>
		public static Mall_Product_Picture GetMall_Product_Picture(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Product_Picture.SelectFieldList + @"
FROM [dbo].[Mall_Product_Picture] 
WHERE 
	[Mall_Product_Picture].[ID] = @ID " + Mall_Product_Picture.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Product_Picture>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Product_Picture by a Mall_Product_Picture's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Product_Picture</returns>
		public static Mall_Product_Picture GetMall_Product_Picture(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Product_Picture.SelectFieldList + @"
FROM [dbo].[Mall_Product_Picture] 
WHERE 
	[Mall_Product_Picture].[ID] = @ID " + Mall_Product_Picture.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Product_Picture>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Picture objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Product_Picture objects.</returns>
		public static EntityList<Mall_Product_Picture> GetMall_Product_Pictures()
		{
			string commandText = @"
SELECT " + Mall_Product_Picture.SelectFieldList + "FROM [dbo].[Mall_Product_Picture] " + Mall_Product_Picture.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Product_Picture>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Product_Picture objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Product_Picture objects.</returns>
        public static EntityList<Mall_Product_Picture> GetMall_Product_Pictures(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product_Picture>(SelectFieldList, "FROM [dbo].[Mall_Product_Picture]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Product_Picture objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Product_Picture objects.</returns>
        public static EntityList<Mall_Product_Picture> GetMall_Product_Pictures(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product_Picture>(SelectFieldList, "FROM [dbo].[Mall_Product_Picture]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Product_Picture objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Product_Picture objects.</returns>
		protected static EntityList<Mall_Product_Picture> GetMall_Product_Pictures(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Product_Pictures(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Picture objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Picture objects.</returns>
		protected static EntityList<Mall_Product_Picture> GetMall_Product_Pictures(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Product_Pictures(string.Empty, where, parameters, Mall_Product_Picture.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Picture objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Picture objects.</returns>
		protected static EntityList<Mall_Product_Picture> GetMall_Product_Pictures(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Product_Pictures(prefix, where, parameters, Mall_Product_Picture.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Picture objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Picture objects.</returns>
		protected static EntityList<Mall_Product_Picture> GetMall_Product_Pictures(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Product_Pictures(string.Empty, where, parameters, Mall_Product_Picture.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Picture objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Picture objects.</returns>
		protected static EntityList<Mall_Product_Picture> GetMall_Product_Pictures(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Product_Pictures(prefix, where, parameters, Mall_Product_Picture.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Picture objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Product_Picture objects.</returns>
		protected static EntityList<Mall_Product_Picture> GetMall_Product_Pictures(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Product_Picture.SelectFieldList + "FROM [dbo].[Mall_Product_Picture] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Product_Picture>(reader);
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
        protected static EntityList<Mall_Product_Picture> GetMall_Product_Pictures(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product_Picture>(SelectFieldList, "FROM [dbo].[Mall_Product_Picture] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Product_Picture objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_Product_PictureCount()
        {
            return GetMall_Product_PictureCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Product_Picture objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_Product_PictureCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Product_Picture] " + where;

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
		public static partial class Mall_Product_Picture_Properties
		{
			public const string ID = "ID";
			public const string ProductID = "ProductID";
			public const string IconPicPath = "IconPicPath";
			public const string MediumPicPath = "MediumPicPath";
			public const string LargePicPath = "LargePicPath";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProductID" , "int:"},
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
