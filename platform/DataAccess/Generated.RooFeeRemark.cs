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
	/// This object represents the properties and methods of a RooFeeRemark.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RooFeeRemark 
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
		private int _rooFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RooFeeID
		{
			[DebuggerStepThrough()]
			get { return this._rooFeeID; }
			set 
			{
				if (this._rooFeeID != value) 
				{
					this._rooFeeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RooFeeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _categoryNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryNote
		{
			[DebuggerStepThrough()]
			get { return this._categoryNote; }
			set 
			{
				if (this._categoryNote != value) 
				{
					this._categoryNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryNote");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _remarkNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RemarkNote
		{
			[DebuggerStepThrough()]
			get { return this._remarkNote; }
			set 
			{
				if (this._remarkNote != value) 
				{
					this._remarkNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("RemarkNote");
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
	[RooFeeID] int,
	[CategoryNote] nvarchar(500),
	[RemarkNote] nvarchar(500),
	[CategoryID] int
);

INSERT INTO [dbo].[RooFeeRemark] (
	[RooFeeRemark].[RooFeeID],
	[RooFeeRemark].[CategoryNote],
	[RooFeeRemark].[RemarkNote],
	[RooFeeRemark].[CategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RooFeeID],
	INSERTED.[CategoryNote],
	INSERTED.[RemarkNote],
	INSERTED.[CategoryID]
into @table
VALUES ( 
	@RooFeeID,
	@CategoryNote,
	@RemarkNote,
	@CategoryID 
); 

SELECT 
	[ID],
	[RooFeeID],
	[CategoryNote],
	[RemarkNote],
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
	[RooFeeID] int,
	[CategoryNote] nvarchar(500),
	[RemarkNote] nvarchar(500),
	[CategoryID] int
);

UPDATE [dbo].[RooFeeRemark] SET 
	[RooFeeRemark].[RooFeeID] = @RooFeeID,
	[RooFeeRemark].[CategoryNote] = @CategoryNote,
	[RooFeeRemark].[RemarkNote] = @RemarkNote,
	[RooFeeRemark].[CategoryID] = @CategoryID 
output 
	INSERTED.[ID],
	INSERTED.[RooFeeID],
	INSERTED.[CategoryNote],
	INSERTED.[RemarkNote],
	INSERTED.[CategoryID]
into @table
WHERE 
	[RooFeeRemark].[ID] = @ID

SELECT 
	[ID],
	[RooFeeID],
	[CategoryNote],
	[RemarkNote],
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
DELETE FROM [dbo].[RooFeeRemark]
WHERE 
	[RooFeeRemark].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RooFeeRemark() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRooFeeRemark(this.ID));
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
	[RooFeeRemark].[ID],
	[RooFeeRemark].[RooFeeID],
	[RooFeeRemark].[CategoryNote],
	[RooFeeRemark].[RemarkNote],
	[RooFeeRemark].[CategoryID]
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
                return "RooFeeRemark";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RooFeeRemark into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="rooFeeID">rooFeeID</param>
		/// <param name="categoryNote">categoryNote</param>
		/// <param name="remarkNote">remarkNote</param>
		/// <param name="categoryID">categoryID</param>
		public static void InsertRooFeeRemark(int @rooFeeID, string @categoryNote, string @remarkNote, int @categoryID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRooFeeRemark(@rooFeeID, @categoryNote, @remarkNote, @categoryID, helper);
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
		/// Insert a RooFeeRemark into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="rooFeeID">rooFeeID</param>
		/// <param name="categoryNote">categoryNote</param>
		/// <param name="remarkNote">remarkNote</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="helper">helper</param>
		internal static void InsertRooFeeRemark(int @rooFeeID, string @categoryNote, string @remarkNote, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RooFeeID] int,
	[CategoryNote] nvarchar(500),
	[RemarkNote] nvarchar(500),
	[CategoryID] int
);

INSERT INTO [dbo].[RooFeeRemark] (
	[RooFeeRemark].[RooFeeID],
	[RooFeeRemark].[CategoryNote],
	[RooFeeRemark].[RemarkNote],
	[RooFeeRemark].[CategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RooFeeID],
	INSERTED.[CategoryNote],
	INSERTED.[RemarkNote],
	INSERTED.[CategoryID]
into @table
VALUES ( 
	@RooFeeID,
	@CategoryNote,
	@RemarkNote,
	@CategoryID 
); 

SELECT 
	[ID],
	[RooFeeID],
	[CategoryNote],
	[RemarkNote],
	[CategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RooFeeID", EntityBase.GetDatabaseValue(@rooFeeID)));
			parameters.Add(new SqlParameter("@CategoryNote", EntityBase.GetDatabaseValue(@categoryNote)));
			parameters.Add(new SqlParameter("@RemarkNote", EntityBase.GetDatabaseValue(@remarkNote)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RooFeeRemark into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="rooFeeID">rooFeeID</param>
		/// <param name="categoryNote">categoryNote</param>
		/// <param name="remarkNote">remarkNote</param>
		/// <param name="categoryID">categoryID</param>
		public static void UpdateRooFeeRemark(int @iD, int @rooFeeID, string @categoryNote, string @remarkNote, int @categoryID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRooFeeRemark(@iD, @rooFeeID, @categoryNote, @remarkNote, @categoryID, helper);
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
		/// Updates a RooFeeRemark into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="rooFeeID">rooFeeID</param>
		/// <param name="categoryNote">categoryNote</param>
		/// <param name="remarkNote">remarkNote</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRooFeeRemark(int @iD, int @rooFeeID, string @categoryNote, string @remarkNote, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RooFeeID] int,
	[CategoryNote] nvarchar(500),
	[RemarkNote] nvarchar(500),
	[CategoryID] int
);

UPDATE [dbo].[RooFeeRemark] SET 
	[RooFeeRemark].[RooFeeID] = @RooFeeID,
	[RooFeeRemark].[CategoryNote] = @CategoryNote,
	[RooFeeRemark].[RemarkNote] = @RemarkNote,
	[RooFeeRemark].[CategoryID] = @CategoryID 
output 
	INSERTED.[ID],
	INSERTED.[RooFeeID],
	INSERTED.[CategoryNote],
	INSERTED.[RemarkNote],
	INSERTED.[CategoryID]
into @table
WHERE 
	[RooFeeRemark].[ID] = @ID

SELECT 
	[ID],
	[RooFeeID],
	[CategoryNote],
	[RemarkNote],
	[CategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RooFeeID", EntityBase.GetDatabaseValue(@rooFeeID)));
			parameters.Add(new SqlParameter("@CategoryNote", EntityBase.GetDatabaseValue(@categoryNote)));
			parameters.Add(new SqlParameter("@RemarkNote", EntityBase.GetDatabaseValue(@remarkNote)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RooFeeRemark from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRooFeeRemark(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRooFeeRemark(@iD, helper);
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
		/// Deletes a RooFeeRemark from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRooFeeRemark(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RooFeeRemark]
WHERE 
	[RooFeeRemark].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RooFeeRemark object.
		/// </summary>
		/// <returns>The newly created RooFeeRemark object.</returns>
		public static RooFeeRemark CreateRooFeeRemark()
		{
			return InitializeNew<RooFeeRemark>();
		}
		
		/// <summary>
		/// Retrieve information for a RooFeeRemark by a RooFeeRemark's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RooFeeRemark</returns>
		public static RooFeeRemark GetRooFeeRemark(int @iD)
		{
			string commandText = @"
SELECT 
" + RooFeeRemark.SelectFieldList + @"
FROM [dbo].[RooFeeRemark] 
WHERE 
	[RooFeeRemark].[ID] = @ID " + RooFeeRemark.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RooFeeRemark>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RooFeeRemark by a RooFeeRemark's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RooFeeRemark</returns>
		public static RooFeeRemark GetRooFeeRemark(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RooFeeRemark.SelectFieldList + @"
FROM [dbo].[RooFeeRemark] 
WHERE 
	[RooFeeRemark].[ID] = @ID " + RooFeeRemark.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RooFeeRemark>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RooFeeRemark objects.
		/// </summary>
		/// <returns>The retrieved collection of RooFeeRemark objects.</returns>
		public static EntityList<RooFeeRemark> GetRooFeeRemarks()
		{
			string commandText = @"
SELECT " + RooFeeRemark.SelectFieldList + "FROM [dbo].[RooFeeRemark] " + RooFeeRemark.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RooFeeRemark>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RooFeeRemark objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RooFeeRemark objects.</returns>
        public static EntityList<RooFeeRemark> GetRooFeeRemarks(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RooFeeRemark>(SelectFieldList, "FROM [dbo].[RooFeeRemark]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RooFeeRemark objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RooFeeRemark objects.</returns>
        public static EntityList<RooFeeRemark> GetRooFeeRemarks(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RooFeeRemark>(SelectFieldList, "FROM [dbo].[RooFeeRemark]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RooFeeRemark objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RooFeeRemark objects.</returns>
		protected static EntityList<RooFeeRemark> GetRooFeeRemarks(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRooFeeRemarks(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RooFeeRemark objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RooFeeRemark objects.</returns>
		protected static EntityList<RooFeeRemark> GetRooFeeRemarks(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRooFeeRemarks(string.Empty, where, parameters, RooFeeRemark.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RooFeeRemark objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RooFeeRemark objects.</returns>
		protected static EntityList<RooFeeRemark> GetRooFeeRemarks(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRooFeeRemarks(prefix, where, parameters, RooFeeRemark.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RooFeeRemark objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RooFeeRemark objects.</returns>
		protected static EntityList<RooFeeRemark> GetRooFeeRemarks(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRooFeeRemarks(string.Empty, where, parameters, RooFeeRemark.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RooFeeRemark objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RooFeeRemark objects.</returns>
		protected static EntityList<RooFeeRemark> GetRooFeeRemarks(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRooFeeRemarks(prefix, where, parameters, RooFeeRemark.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RooFeeRemark objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RooFeeRemark objects.</returns>
		protected static EntityList<RooFeeRemark> GetRooFeeRemarks(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RooFeeRemark.SelectFieldList + "FROM [dbo].[RooFeeRemark] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RooFeeRemark>(reader);
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
        protected static EntityList<RooFeeRemark> GetRooFeeRemarks(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RooFeeRemark>(SelectFieldList, "FROM [dbo].[RooFeeRemark] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RooFeeRemark objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRooFeeRemarkCount()
        {
            return GetRooFeeRemarkCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RooFeeRemark objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRooFeeRemarkCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RooFeeRemark] " + where;

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
		public static partial class RooFeeRemark_Properties
		{
			public const string ID = "ID";
			public const string RooFeeID = "RooFeeID";
			public const string CategoryNote = "CategoryNote";
			public const string RemarkNote = "RemarkNote";
			public const string CategoryID = "CategoryID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RooFeeID" , "int:"},
    			 {"CategoryNote" , "string:"},
    			 {"RemarkNote" , "string:"},
    			 {"CategoryID" , "int:"},
            };
		}
		#endregion
	}
}
