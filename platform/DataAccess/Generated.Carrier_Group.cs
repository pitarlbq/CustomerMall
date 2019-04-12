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
	/// This object represents the properties and methods of a Carrier_Group.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("CarrierID: {CarrierID}, GroupID: {GroupID}")]
	public partial class Carrier_Group 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _carrierID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int CarrierID
		{
			[DebuggerStepThrough()]
			get { return this._carrierID; }
			set 
			{
				if (this._carrierID != value) 
				{
					this._carrierID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CarrierID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _groupID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int GroupID
		{
			[DebuggerStepThrough()]
			get { return this._groupID; }
			set 
			{
				if (this._groupID != value) 
				{
					this._groupID = value;
					this.IsDirty = true;	
					OnPropertyChanged("GroupID");
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
	[CarrierID] int,
	[GroupID] int
);

INSERT INTO [dbo].[Carrier_Group] (
	[Carrier_Group].[CarrierID],
	[Carrier_Group].[GroupID]
) 
output 
	INSERTED.[CarrierID],
	INSERTED.[GroupID]
into @table
VALUES ( 
	@CarrierID,
	@GroupID 
); 

SELECT 
	[CarrierID],
	[GroupID] 
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
	[CarrierID] int,
	[GroupID] int
);

UPDATE [dbo].[Carrier_Group] SET 
 
output 
	INSERTED.[CarrierID],
	INSERTED.[GroupID]
into @table
WHERE 
	[Carrier_Group].[CarrierID] = @CarrierID
	AND [Carrier_Group].[GroupID] = @GroupID

SELECT 
	[CarrierID],
	[GroupID] 
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
DELETE FROM [dbo].[Carrier_Group]
WHERE 
	[Carrier_Group].[CarrierID] = @CarrierID
	AND [Carrier_Group].[GroupID] = @GroupID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Carrier_Group() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCarrier_Group(this.CarrierID, this.GroupID));
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
	[Carrier_Group].[CarrierID],
	[Carrier_Group].[GroupID]
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
                return "Carrier_Group";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Carrier_Group into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="carrierID">carrierID</param>
		/// <param name="groupID">groupID</param>
		public static void InsertCarrier_Group(int @carrierID, int @groupID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCarrier_Group(@carrierID, @groupID, helper);
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
		/// Insert a Carrier_Group into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="carrierID">carrierID</param>
		/// <param name="groupID">groupID</param>
		/// <param name="helper">helper</param>
		internal static void InsertCarrier_Group(int @carrierID, int @groupID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[CarrierID] int,
	[GroupID] int
);

INSERT INTO [dbo].[Carrier_Group] (
	[Carrier_Group].[CarrierID],
	[Carrier_Group].[GroupID]
) 
output 
	INSERTED.[CarrierID],
	INSERTED.[GroupID]
into @table
VALUES ( 
	@CarrierID,
	@GroupID 
); 

SELECT 
	[CarrierID],
	[GroupID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CarrierID", EntityBase.GetDatabaseValue(@carrierID)));
			parameters.Add(new SqlParameter("@GroupID", EntityBase.GetDatabaseValue(@groupID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Carrier_Group into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="carrierID">carrierID</param>
		/// <param name="groupID">groupID</param>
		public static void UpdateCarrier_Group(int @carrierID, int @groupID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCarrier_Group(@carrierID, @groupID, helper);
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
		/// Updates a Carrier_Group into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="carrierID">carrierID</param>
		/// <param name="groupID">groupID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCarrier_Group(int @carrierID, int @groupID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[CarrierID] int,
	[GroupID] int
);

UPDATE [dbo].[Carrier_Group] SET 
 
output 
	INSERTED.[CarrierID],
	INSERTED.[GroupID]
into @table
WHERE 
	[Carrier_Group].[CarrierID] = @CarrierID
	AND [Carrier_Group].[GroupID] = @GroupID

SELECT 
	[CarrierID],
	[GroupID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CarrierID", EntityBase.GetDatabaseValue(@carrierID)));
			parameters.Add(new SqlParameter("@GroupID", EntityBase.GetDatabaseValue(@groupID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Carrier_Group from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="carrierID">carrierID</param>
		/// <param name="groupID">groupID</param>
		public static void DeleteCarrier_Group(int @carrierID, int @groupID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCarrier_Group(@carrierID, @groupID, helper);
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
		/// Deletes a Carrier_Group from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="carrierID">carrierID</param>
		/// <param name="groupID">groupID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCarrier_Group(int @carrierID, int @groupID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Carrier_Group]
WHERE 
	[Carrier_Group].[CarrierID] = @CarrierID
	AND [Carrier_Group].[GroupID] = @GroupID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CarrierID", @carrierID));
			parameters.Add(new SqlParameter("@GroupID", @groupID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Carrier_Group object.
		/// </summary>
		/// <returns>The newly created Carrier_Group object.</returns>
		public static Carrier_Group CreateCarrier_Group()
		{
			return InitializeNew<Carrier_Group>();
		}
		
		/// <summary>
		/// Retrieve information for a Carrier_Group by a Carrier_Group's unique identifier.
		/// </summary>
		/// <param name="carrierID">carrierID</param>
		/// <param name="groupID">groupID</param>
		/// <returns>Carrier_Group</returns>
		public static Carrier_Group GetCarrier_Group(int @carrierID, int @groupID)
		{
			string commandText = @"
SELECT 
" + Carrier_Group.SelectFieldList + @"
FROM [dbo].[Carrier_Group] 
WHERE 
	[Carrier_Group].[CarrierID] = @CarrierID
	AND [Carrier_Group].[GroupID] = @GroupID " + Carrier_Group.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CarrierID", @carrierID));
			parameters.Add(new SqlParameter("@GroupID", @groupID));
			
			return GetOne<Carrier_Group>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Carrier_Group by a Carrier_Group's unique identifier.
		/// </summary>
		/// <param name="carrierID">carrierID</param>
		/// <param name="groupID">groupID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Carrier_Group</returns>
		public static Carrier_Group GetCarrier_Group(int @carrierID, int @groupID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Carrier_Group.SelectFieldList + @"
FROM [dbo].[Carrier_Group] 
WHERE 
	[Carrier_Group].[CarrierID] = @CarrierID
	AND [Carrier_Group].[GroupID] = @GroupID " + Carrier_Group.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CarrierID", @carrierID));
			parameters.Add(new SqlParameter("@GroupID", @groupID));
			
			return GetOne<Carrier_Group>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Carrier_Group objects.
		/// </summary>
		/// <returns>The retrieved collection of Carrier_Group objects.</returns>
		public static EntityList<Carrier_Group> GetCarrier_Groups()
		{
			string commandText = @"
SELECT " + Carrier_Group.SelectFieldList + "FROM [dbo].[Carrier_Group] " + Carrier_Group.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Carrier_Group>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Carrier_Group objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Carrier_Group objects.</returns>
        public static EntityList<Carrier_Group> GetCarrier_Groups(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Carrier_Group>(SelectFieldList, "FROM [dbo].[Carrier_Group]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Carrier_Group objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Carrier_Group objects.</returns>
        public static EntityList<Carrier_Group> GetCarrier_Groups(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Carrier_Group>(SelectFieldList, "FROM [dbo].[Carrier_Group]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Carrier_Group objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Carrier_Group objects.</returns>
		protected static EntityList<Carrier_Group> GetCarrier_Groups(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCarrier_Groups(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Carrier_Group objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Carrier_Group objects.</returns>
		protected static EntityList<Carrier_Group> GetCarrier_Groups(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCarrier_Groups(string.Empty, where, parameters, Carrier_Group.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Carrier_Group objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Carrier_Group objects.</returns>
		protected static EntityList<Carrier_Group> GetCarrier_Groups(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCarrier_Groups(prefix, where, parameters, Carrier_Group.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Carrier_Group objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Carrier_Group objects.</returns>
		protected static EntityList<Carrier_Group> GetCarrier_Groups(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCarrier_Groups(string.Empty, where, parameters, Carrier_Group.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Carrier_Group objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Carrier_Group objects.</returns>
		protected static EntityList<Carrier_Group> GetCarrier_Groups(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCarrier_Groups(prefix, where, parameters, Carrier_Group.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Carrier_Group objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Carrier_Group objects.</returns>
		protected static EntityList<Carrier_Group> GetCarrier_Groups(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Carrier_Group.SelectFieldList + "FROM [dbo].[Carrier_Group] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Carrier_Group>(reader);
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
        protected static EntityList<Carrier_Group> GetCarrier_Groups(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Carrier_Group>(SelectFieldList, "FROM [dbo].[Carrier_Group] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class Carrier_GroupProperties
		{
			public const string CarrierID = "CarrierID";
			public const string GroupID = "GroupID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"CarrierID" , "int:"},
    			 {"GroupID" , "int:"},
            };
		}
		#endregion
	}
}
