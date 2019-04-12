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
	/// This object represents the properties and methods of a Carrier.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Carrier 
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
		private string _carrierName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CarrierName
		{
			[DebuggerStepThrough()]
			get { return this._carrierName; }
			set 
			{
				if (this._carrierName != value) 
				{
					this._carrierName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CarrierName");
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
	[CarrierName] nvarchar(50)
);

INSERT INTO [dbo].[Carrier] (
	[Carrier].[CarrierName]
) 
output 
	INSERTED.[ID],
	INSERTED.[CarrierName]
into @table
VALUES ( 
	@CarrierName 
); 

SELECT 
	[ID],
	[CarrierName] 
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
	[CarrierName] nvarchar(50)
);

UPDATE [dbo].[Carrier] SET 
	[Carrier].[CarrierName] = @CarrierName 
output 
	INSERTED.[ID],
	INSERTED.[CarrierName]
into @table
WHERE 
	[Carrier].[ID] = @ID

SELECT 
	[ID],
	[CarrierName] 
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
DELETE FROM [dbo].[Carrier]
WHERE 
	[Carrier].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Carrier() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCarrier(this.ID));
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
	[Carrier].[ID],
	[Carrier].[CarrierName]
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
                return "Carrier";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Carrier into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="carrierName">carrierName</param>
		public static void InsertCarrier(string @carrierName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCarrier(@carrierName, helper);
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
		/// Insert a Carrier into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="carrierName">carrierName</param>
		/// <param name="helper">helper</param>
		internal static void InsertCarrier(string @carrierName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CarrierName] nvarchar(50)
);

INSERT INTO [dbo].[Carrier] (
	[Carrier].[CarrierName]
) 
output 
	INSERTED.[ID],
	INSERTED.[CarrierName]
into @table
VALUES ( 
	@CarrierName 
); 

SELECT 
	[ID],
	[CarrierName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CarrierName", EntityBase.GetDatabaseValue(@carrierName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Carrier into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="carrierName">carrierName</param>
		public static void UpdateCarrier(int @iD, string @carrierName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCarrier(@iD, @carrierName, helper);
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
		/// Updates a Carrier into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="carrierName">carrierName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCarrier(int @iD, string @carrierName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CarrierName] nvarchar(50)
);

UPDATE [dbo].[Carrier] SET 
	[Carrier].[CarrierName] = @CarrierName 
output 
	INSERTED.[ID],
	INSERTED.[CarrierName]
into @table
WHERE 
	[Carrier].[ID] = @ID

SELECT 
	[ID],
	[CarrierName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CarrierName", EntityBase.GetDatabaseValue(@carrierName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Carrier from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCarrier(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCarrier(@iD, helper);
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
		/// Deletes a Carrier from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCarrier(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Carrier]
WHERE 
	[Carrier].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Carrier object.
		/// </summary>
		/// <returns>The newly created Carrier object.</returns>
		public static Carrier CreateCarrier()
		{
			return InitializeNew<Carrier>();
		}
		
		/// <summary>
		/// Retrieve information for a Carrier by a Carrier's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Carrier</returns>
		public static Carrier GetCarrier(int @iD)
		{
			string commandText = @"
SELECT 
" + Carrier.SelectFieldList + @"
FROM [dbo].[Carrier] 
WHERE 
	[Carrier].[ID] = @ID " + Carrier.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Carrier>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Carrier by a Carrier's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Carrier</returns>
		public static Carrier GetCarrier(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Carrier.SelectFieldList + @"
FROM [dbo].[Carrier] 
WHERE 
	[Carrier].[ID] = @ID " + Carrier.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Carrier>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Carrier objects.
		/// </summary>
		/// <returns>The retrieved collection of Carrier objects.</returns>
		public static EntityList<Carrier> GetCarriers()
		{
			string commandText = @"
SELECT " + Carrier.SelectFieldList + "FROM [dbo].[Carrier] " + Carrier.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Carrier>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Carrier objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Carrier objects.</returns>
        public static EntityList<Carrier> GetCarriers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Carrier>(SelectFieldList, "FROM [dbo].[Carrier]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Carrier objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Carrier objects.</returns>
        public static EntityList<Carrier> GetCarriers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Carrier>(SelectFieldList, "FROM [dbo].[Carrier]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Carrier objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Carrier objects.</returns>
		protected static EntityList<Carrier> GetCarriers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCarriers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Carrier objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Carrier objects.</returns>
		protected static EntityList<Carrier> GetCarriers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCarriers(string.Empty, where, parameters, Carrier.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Carrier objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Carrier objects.</returns>
		protected static EntityList<Carrier> GetCarriers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCarriers(prefix, where, parameters, Carrier.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Carrier objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Carrier objects.</returns>
		protected static EntityList<Carrier> GetCarriers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCarriers(string.Empty, where, parameters, Carrier.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Carrier objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Carrier objects.</returns>
		protected static EntityList<Carrier> GetCarriers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCarriers(prefix, where, parameters, Carrier.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Carrier objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Carrier objects.</returns>
		protected static EntityList<Carrier> GetCarriers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Carrier.SelectFieldList + "FROM [dbo].[Carrier] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Carrier>(reader);
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
        protected static EntityList<Carrier> GetCarriers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Carrier>(SelectFieldList, "FROM [dbo].[Carrier] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class CarrierProperties
		{
			public const string ID = "ID";
			public const string CarrierName = "CarrierName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CarrierName" , "string:"},
            };
		}
		#endregion
	}
}
