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
	/// This object represents the properties and methods of a ChargeSummary_Biao.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ChargeID: {ChargeID}, ChargeBiaoID: {ChargeBiaoID}")]
	public partial class ChargeSummary_Biao 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int ChargeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeID; }
			set 
			{
				if (this._chargeID != value) 
				{
					this._chargeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeBiaoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int ChargeBiaoID
		{
			[DebuggerStepThrough()]
			get { return this._chargeBiaoID; }
			set 
			{
				if (this._chargeBiaoID != value) 
				{
					this._chargeBiaoID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeBiaoID");
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
	[ChargeID] int,
	[ChargeBiaoID] int
);

INSERT INTO [dbo].[ChargeSummary_Biao] (
	[ChargeSummary_Biao].[ChargeID],
	[ChargeSummary_Biao].[ChargeBiaoID]
) 
output 
	INSERTED.[ChargeID],
	INSERTED.[ChargeBiaoID]
into @table
VALUES ( 
	@ChargeID,
	@ChargeBiaoID 
); 

SELECT 
	[ChargeID],
	[ChargeBiaoID] 
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
	[ChargeID] int,
	[ChargeBiaoID] int
);

UPDATE [dbo].[ChargeSummary_Biao] SET 
 
output 
	INSERTED.[ChargeID],
	INSERTED.[ChargeBiaoID]
into @table
WHERE 
	[ChargeSummary_Biao].[ChargeID] = @ChargeID
	AND [ChargeSummary_Biao].[ChargeBiaoID] = @ChargeBiaoID

SELECT 
	[ChargeID],
	[ChargeBiaoID] 
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
DELETE FROM [dbo].[ChargeSummary_Biao]
WHERE 
	[ChargeSummary_Biao].[ChargeID] = @ChargeID
	AND [ChargeSummary_Biao].[ChargeBiaoID] = @ChargeBiaoID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeSummary_Biao() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeSummary_Biao(this.ChargeID, this.ChargeBiaoID));
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
	[ChargeSummary_Biao].[ChargeID],
	[ChargeSummary_Biao].[ChargeBiaoID]
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
                return "ChargeSummary_Biao";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeSummary_Biao into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
		public static void InsertChargeSummary_Biao(int @chargeID, int @chargeBiaoID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeSummary_Biao(@chargeID, @chargeBiaoID, helper);
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
		/// Insert a ChargeSummary_Biao into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeSummary_Biao(int @chargeID, int @chargeBiaoID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ChargeID] int,
	[ChargeBiaoID] int
);

INSERT INTO [dbo].[ChargeSummary_Biao] (
	[ChargeSummary_Biao].[ChargeID],
	[ChargeSummary_Biao].[ChargeBiaoID]
) 
output 
	INSERTED.[ChargeID],
	INSERTED.[ChargeBiaoID]
into @table
VALUES ( 
	@ChargeID,
	@ChargeBiaoID 
); 

SELECT 
	[ChargeID],
	[ChargeBiaoID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@ChargeBiaoID", EntityBase.GetDatabaseValue(@chargeBiaoID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeSummary_Biao into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
		public static void UpdateChargeSummary_Biao(int @chargeID, int @chargeBiaoID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeSummary_Biao(@chargeID, @chargeBiaoID, helper);
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
		/// Updates a ChargeSummary_Biao into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeSummary_Biao(int @chargeID, int @chargeBiaoID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ChargeID] int,
	[ChargeBiaoID] int
);

UPDATE [dbo].[ChargeSummary_Biao] SET 
 
output 
	INSERTED.[ChargeID],
	INSERTED.[ChargeBiaoID]
into @table
WHERE 
	[ChargeSummary_Biao].[ChargeID] = @ChargeID
	AND [ChargeSummary_Biao].[ChargeBiaoID] = @ChargeBiaoID

SELECT 
	[ChargeID],
	[ChargeBiaoID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@ChargeBiaoID", EntityBase.GetDatabaseValue(@chargeBiaoID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeSummary_Biao from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
		public static void DeleteChargeSummary_Biao(int @chargeID, int @chargeBiaoID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeSummary_Biao(@chargeID, @chargeBiaoID, helper);
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
		/// Deletes a ChargeSummary_Biao from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeSummary_Biao(int @chargeID, int @chargeBiaoID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeSummary_Biao]
WHERE 
	[ChargeSummary_Biao].[ChargeID] = @ChargeID
	AND [ChargeSummary_Biao].[ChargeBiaoID] = @ChargeBiaoID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeID", @chargeID));
			parameters.Add(new SqlParameter("@ChargeBiaoID", @chargeBiaoID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeSummary_Biao object.
		/// </summary>
		/// <returns>The newly created ChargeSummary_Biao object.</returns>
		public static ChargeSummary_Biao CreateChargeSummary_Biao()
		{
			return InitializeNew<ChargeSummary_Biao>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeSummary_Biao by a ChargeSummary_Biao's unique identifier.
		/// </summary>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
		/// <returns>ChargeSummary_Biao</returns>
		public static ChargeSummary_Biao GetChargeSummary_Biao(int @chargeID, int @chargeBiaoID)
		{
			string commandText = @"
SELECT 
" + ChargeSummary_Biao.SelectFieldList + @"
FROM [dbo].[ChargeSummary_Biao] 
WHERE 
	[ChargeSummary_Biao].[ChargeID] = @ChargeID
	AND [ChargeSummary_Biao].[ChargeBiaoID] = @ChargeBiaoID " + ChargeSummary_Biao.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeID", @chargeID));
			parameters.Add(new SqlParameter("@ChargeBiaoID", @chargeBiaoID));
			
			return GetOne<ChargeSummary_Biao>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeSummary_Biao by a ChargeSummary_Biao's unique identifier.
		/// </summary>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeSummary_Biao</returns>
		public static ChargeSummary_Biao GetChargeSummary_Biao(int @chargeID, int @chargeBiaoID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeSummary_Biao.SelectFieldList + @"
FROM [dbo].[ChargeSummary_Biao] 
WHERE 
	[ChargeSummary_Biao].[ChargeID] = @ChargeID
	AND [ChargeSummary_Biao].[ChargeBiaoID] = @ChargeBiaoID " + ChargeSummary_Biao.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeID", @chargeID));
			parameters.Add(new SqlParameter("@ChargeBiaoID", @chargeBiaoID));
			
			return GetOne<ChargeSummary_Biao>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary_Biao objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeSummary_Biao objects.</returns>
		public static EntityList<ChargeSummary_Biao> GetChargeSummary_Biaos()
		{
			string commandText = @"
SELECT " + ChargeSummary_Biao.SelectFieldList + "FROM [dbo].[ChargeSummary_Biao] " + ChargeSummary_Biao.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeSummary_Biao>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeSummary_Biao objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeSummary_Biao objects.</returns>
        public static EntityList<ChargeSummary_Biao> GetChargeSummary_Biaos(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeSummary_Biao>(SelectFieldList, "FROM [dbo].[ChargeSummary_Biao]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeSummary_Biao objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeSummary_Biao objects.</returns>
        public static EntityList<ChargeSummary_Biao> GetChargeSummary_Biaos(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeSummary_Biao>(SelectFieldList, "FROM [dbo].[ChargeSummary_Biao]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeSummary_Biao objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeSummary_Biao objects.</returns>
		protected static EntityList<ChargeSummary_Biao> GetChargeSummary_Biaos(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeSummary_Biaos(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary_Biao objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeSummary_Biao objects.</returns>
		protected static EntityList<ChargeSummary_Biao> GetChargeSummary_Biaos(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeSummary_Biaos(string.Empty, where, parameters, ChargeSummary_Biao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary_Biao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeSummary_Biao objects.</returns>
		protected static EntityList<ChargeSummary_Biao> GetChargeSummary_Biaos(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeSummary_Biaos(prefix, where, parameters, ChargeSummary_Biao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary_Biao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeSummary_Biao objects.</returns>
		protected static EntityList<ChargeSummary_Biao> GetChargeSummary_Biaos(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeSummary_Biaos(string.Empty, where, parameters, ChargeSummary_Biao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary_Biao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeSummary_Biao objects.</returns>
		protected static EntityList<ChargeSummary_Biao> GetChargeSummary_Biaos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeSummary_Biaos(prefix, where, parameters, ChargeSummary_Biao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary_Biao objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeSummary_Biao objects.</returns>
		protected static EntityList<ChargeSummary_Biao> GetChargeSummary_Biaos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeSummary_Biao.SelectFieldList + "FROM [dbo].[ChargeSummary_Biao] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeSummary_Biao>(reader);
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
        protected static EntityList<ChargeSummary_Biao> GetChargeSummary_Biaos(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeSummary_Biao>(SelectFieldList, "FROM [dbo].[ChargeSummary_Biao] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ChargeSummary_Biao objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeSummary_BiaoCount()
        {
            return GetChargeSummary_BiaoCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ChargeSummary_Biao objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeSummary_BiaoCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ChargeSummary_Biao] " + where;

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
		public static partial class ChargeSummary_Biao_Properties
		{
			public const string ChargeID = "ChargeID";
			public const string ChargeBiaoID = "ChargeBiaoID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ChargeID" , "int:"},
    			 {"ChargeBiaoID" , "int:"},
            };
		}
		#endregion
	}
}
