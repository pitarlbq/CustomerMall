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
	/// This object represents the properties and methods of a RoomPreCharge.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("RoomID: {RoomID}")]
	public partial class RoomPreCharge 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int RoomID
		{
			[DebuggerStepThrough()]
			get { return this._roomID; }
			set 
			{
				if (this._roomID != value) 
				{
					this._roomID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _balance = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal Balance
		{
			[DebuggerStepThrough()]
			get { return this._balance; }
			set 
			{
				if (this._balance != value) 
				{
					this._balance = value;
					this.IsDirty = true;	
					OnPropertyChanged("Balance");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _guaranteeFee = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal GuaranteeFee
		{
			[DebuggerStepThrough()]
			get { return this._guaranteeFee; }
			set 
			{
				if (this._guaranteeFee != value) 
				{
					this._guaranteeFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("GuaranteeFee");
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
	[RoomID] int,
	[Balance] decimal(18, 2),
	[GuaranteeFee] decimal(18, 2)
);

INSERT INTO [dbo].[RoomPreCharge] (
	[RoomPreCharge].[RoomID],
	[RoomPreCharge].[Balance],
	[RoomPreCharge].[GuaranteeFee]
) 
output 
	INSERTED.[RoomID],
	INSERTED.[Balance],
	INSERTED.[GuaranteeFee]
into @table
VALUES ( 
	@RoomID,
	@Balance,
	@GuaranteeFee 
); 

SELECT 
	[RoomID],
	[Balance],
	[GuaranteeFee] 
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
	[RoomID] int,
	[Balance] decimal(18, 2),
	[GuaranteeFee] decimal(18, 2)
);

UPDATE [dbo].[RoomPreCharge] SET 
	[RoomPreCharge].[Balance] = @Balance,
	[RoomPreCharge].[GuaranteeFee] = @GuaranteeFee 
output 
	INSERTED.[RoomID],
	INSERTED.[Balance],
	INSERTED.[GuaranteeFee]
into @table
WHERE 
	[RoomPreCharge].[RoomID] = @RoomID

SELECT 
	[RoomID],
	[Balance],
	[GuaranteeFee] 
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
DELETE FROM [dbo].[RoomPreCharge]
WHERE 
	[RoomPreCharge].[RoomID] = @RoomID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomPreCharge() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomPreCharge(this.RoomID));
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
	[RoomPreCharge].[RoomID],
	[RoomPreCharge].[Balance],
	[RoomPreCharge].[GuaranteeFee]
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
                return "RoomPreCharge";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomPreCharge into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="balance">balance</param>
		/// <param name="guaranteeFee">guaranteeFee</param>
		public static void InsertRoomPreCharge(int @roomID, decimal @balance, decimal @guaranteeFee)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomPreCharge(@roomID, @balance, @guaranteeFee, helper);
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
		/// Insert a RoomPreCharge into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="balance">balance</param>
		/// <param name="guaranteeFee">guaranteeFee</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomPreCharge(int @roomID, decimal @balance, decimal @guaranteeFee, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[RoomID] int,
	[Balance] decimal(18, 2),
	[GuaranteeFee] decimal(18, 2)
);

INSERT INTO [dbo].[RoomPreCharge] (
	[RoomPreCharge].[RoomID],
	[RoomPreCharge].[Balance],
	[RoomPreCharge].[GuaranteeFee]
) 
output 
	INSERTED.[RoomID],
	INSERTED.[Balance],
	INSERTED.[GuaranteeFee]
into @table
VALUES ( 
	@RoomID,
	@Balance,
	@GuaranteeFee 
); 

SELECT 
	[RoomID],
	[Balance],
	[GuaranteeFee] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@Balance", EntityBase.GetDatabaseValue(@balance)));
			parameters.Add(new SqlParameter("@GuaranteeFee", EntityBase.GetDatabaseValue(@guaranteeFee)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomPreCharge into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="balance">balance</param>
		/// <param name="guaranteeFee">guaranteeFee</param>
		public static void UpdateRoomPreCharge(int @roomID, decimal @balance, decimal @guaranteeFee)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomPreCharge(@roomID, @balance, @guaranteeFee, helper);
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
		/// Updates a RoomPreCharge into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="balance">balance</param>
		/// <param name="guaranteeFee">guaranteeFee</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomPreCharge(int @roomID, decimal @balance, decimal @guaranteeFee, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[RoomID] int,
	[Balance] decimal(18, 2),
	[GuaranteeFee] decimal(18, 2)
);

UPDATE [dbo].[RoomPreCharge] SET 
	[RoomPreCharge].[Balance] = @Balance,
	[RoomPreCharge].[GuaranteeFee] = @GuaranteeFee 
output 
	INSERTED.[RoomID],
	INSERTED.[Balance],
	INSERTED.[GuaranteeFee]
into @table
WHERE 
	[RoomPreCharge].[RoomID] = @RoomID

SELECT 
	[RoomID],
	[Balance],
	[GuaranteeFee] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@Balance", EntityBase.GetDatabaseValue(@balance)));
			parameters.Add(new SqlParameter("@GuaranteeFee", EntityBase.GetDatabaseValue(@guaranteeFee)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomPreCharge from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		public static void DeleteRoomPreCharge(int @roomID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomPreCharge(@roomID, helper);
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
		/// Deletes a RoomPreCharge from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomPreCharge(int @roomID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomPreCharge]
WHERE 
	[RoomPreCharge].[RoomID] = @RoomID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", @roomID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomPreCharge object.
		/// </summary>
		/// <returns>The newly created RoomPreCharge object.</returns>
		public static RoomPreCharge CreateRoomPreCharge()
		{
			return InitializeNew<RoomPreCharge>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomPreCharge by a RoomPreCharge's unique identifier.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <returns>RoomPreCharge</returns>
		public static RoomPreCharge GetRoomPreCharge(int @roomID)
		{
			string commandText = @"
SELECT 
" + RoomPreCharge.SelectFieldList + @"
FROM [dbo].[RoomPreCharge] 
WHERE 
	[RoomPreCharge].[RoomID] = @RoomID " + RoomPreCharge.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", @roomID));
			
			return GetOne<RoomPreCharge>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomPreCharge by a RoomPreCharge's unique identifier.
		/// </summary>
		/// <param name="roomID">roomID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomPreCharge</returns>
		public static RoomPreCharge GetRoomPreCharge(int @roomID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomPreCharge.SelectFieldList + @"
FROM [dbo].[RoomPreCharge] 
WHERE 
	[RoomPreCharge].[RoomID] = @RoomID " + RoomPreCharge.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", @roomID));
			
			return GetOne<RoomPreCharge>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomPreCharge objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomPreCharge objects.</returns>
		public static EntityList<RoomPreCharge> GetRoomPreCharges()
		{
			string commandText = @"
SELECT " + RoomPreCharge.SelectFieldList + "FROM [dbo].[RoomPreCharge] " + RoomPreCharge.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomPreCharge>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomPreCharge objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomPreCharge objects.</returns>
        public static EntityList<RoomPreCharge> GetRoomPreCharges(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPreCharge>(SelectFieldList, "FROM [dbo].[RoomPreCharge]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomPreCharge objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomPreCharge objects.</returns>
        public static EntityList<RoomPreCharge> GetRoomPreCharges(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPreCharge>(SelectFieldList, "FROM [dbo].[RoomPreCharge]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomPreCharge objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomPreCharge objects.</returns>
		protected static EntityList<RoomPreCharge> GetRoomPreCharges(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPreCharges(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomPreCharge objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomPreCharge objects.</returns>
		protected static EntityList<RoomPreCharge> GetRoomPreCharges(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPreCharges(string.Empty, where, parameters, RoomPreCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPreCharge objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomPreCharge objects.</returns>
		protected static EntityList<RoomPreCharge> GetRoomPreCharges(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPreCharges(prefix, where, parameters, RoomPreCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPreCharge objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomPreCharge objects.</returns>
		protected static EntityList<RoomPreCharge> GetRoomPreCharges(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomPreCharges(string.Empty, where, parameters, RoomPreCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPreCharge objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomPreCharge objects.</returns>
		protected static EntityList<RoomPreCharge> GetRoomPreCharges(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomPreCharges(prefix, where, parameters, RoomPreCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPreCharge objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomPreCharge objects.</returns>
		protected static EntityList<RoomPreCharge> GetRoomPreCharges(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomPreCharge.SelectFieldList + "FROM [dbo].[RoomPreCharge] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomPreCharge>(reader);
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
        protected static EntityList<RoomPreCharge> GetRoomPreCharges(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPreCharge>(SelectFieldList, "FROM [dbo].[RoomPreCharge] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class RoomPreChargeProperties
		{
			public const string RoomID = "RoomID";
			public const string Balance = "Balance";
			public const string GuaranteeFee = "GuaranteeFee";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"RoomID" , "int:"},
    			 {"Balance" , "decimal:"},
    			 {"GuaranteeFee" , "decimal:"},
            };
		}
		#endregion
	}
}
