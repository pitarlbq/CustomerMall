﻿using System;
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
	/// This object represents the properties and methods of a Wechat_LotteryChecker.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_LotteryChecker 
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
		private int _activityID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ActivityID
		{
			[DebuggerStepThrough()]
			get { return this._activityID; }
			set 
			{
				if (this._activityID != value) 
				{
					this._activityID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ActivityID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
			set 
			{
				if (this._userID != value) 
				{
					this._userID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserID");
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
	[ActivityID] int,
	[UserID] int
);

INSERT INTO [dbo].[Wechat_LotteryChecker] (
	[Wechat_LotteryChecker].[ActivityID],
	[Wechat_LotteryChecker].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@ActivityID,
	@UserID 
); 

SELECT 
	[ID],
	[ActivityID],
	[UserID] 
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
	[ActivityID] int,
	[UserID] int
);

UPDATE [dbo].[Wechat_LotteryChecker] SET 
	[Wechat_LotteryChecker].[ActivityID] = @ActivityID,
	[Wechat_LotteryChecker].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[UserID]
into @table
WHERE 
	[Wechat_LotteryChecker].[ID] = @ID

SELECT 
	[ID],
	[ActivityID],
	[UserID] 
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
DELETE FROM [dbo].[Wechat_LotteryChecker]
WHERE 
	[Wechat_LotteryChecker].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_LotteryChecker() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_LotteryChecker(this.ID));
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
	[Wechat_LotteryChecker].[ID],
	[Wechat_LotteryChecker].[ActivityID],
	[Wechat_LotteryChecker].[UserID]
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
                return "Wechat_LotteryChecker";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_LotteryChecker into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="activityID">activityID</param>
		/// <param name="userID">userID</param>
		public static void InsertWechat_LotteryChecker(int @activityID, int @userID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_LotteryChecker(@activityID, @userID, helper);
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
		/// Insert a Wechat_LotteryChecker into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="activityID">activityID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_LotteryChecker(int @activityID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ActivityID] int,
	[UserID] int
);

INSERT INTO [dbo].[Wechat_LotteryChecker] (
	[Wechat_LotteryChecker].[ActivityID],
	[Wechat_LotteryChecker].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@ActivityID,
	@UserID 
); 

SELECT 
	[ID],
	[ActivityID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ActivityID", EntityBase.GetDatabaseValue(@activityID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_LotteryChecker into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="activityID">activityID</param>
		/// <param name="userID">userID</param>
		public static void UpdateWechat_LotteryChecker(int @iD, int @activityID, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_LotteryChecker(@iD, @activityID, @userID, helper);
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
		/// Updates a Wechat_LotteryChecker into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="activityID">activityID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_LotteryChecker(int @iD, int @activityID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ActivityID] int,
	[UserID] int
);

UPDATE [dbo].[Wechat_LotteryChecker] SET 
	[Wechat_LotteryChecker].[ActivityID] = @ActivityID,
	[Wechat_LotteryChecker].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[UserID]
into @table
WHERE 
	[Wechat_LotteryChecker].[ID] = @ID

SELECT 
	[ID],
	[ActivityID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ActivityID", EntityBase.GetDatabaseValue(@activityID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_LotteryChecker from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_LotteryChecker(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_LotteryChecker(@iD, helper);
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
		/// Deletes a Wechat_LotteryChecker from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_LotteryChecker(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_LotteryChecker]
WHERE 
	[Wechat_LotteryChecker].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_LotteryChecker object.
		/// </summary>
		/// <returns>The newly created Wechat_LotteryChecker object.</returns>
		public static Wechat_LotteryChecker CreateWechat_LotteryChecker()
		{
			return InitializeNew<Wechat_LotteryChecker>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_LotteryChecker by a Wechat_LotteryChecker's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_LotteryChecker</returns>
		public static Wechat_LotteryChecker GetWechat_LotteryChecker(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_LotteryChecker.SelectFieldList + @"
FROM [dbo].[Wechat_LotteryChecker] 
WHERE 
	[Wechat_LotteryChecker].[ID] = @ID " + Wechat_LotteryChecker.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_LotteryChecker>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_LotteryChecker by a Wechat_LotteryChecker's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_LotteryChecker</returns>
		public static Wechat_LotteryChecker GetWechat_LotteryChecker(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_LotteryChecker.SelectFieldList + @"
FROM [dbo].[Wechat_LotteryChecker] 
WHERE 
	[Wechat_LotteryChecker].[ID] = @ID " + Wechat_LotteryChecker.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_LotteryChecker>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryChecker objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_LotteryChecker objects.</returns>
		public static EntityList<Wechat_LotteryChecker> GetWechat_LotteryCheckers()
		{
			string commandText = @"
SELECT " + Wechat_LotteryChecker.SelectFieldList + "FROM [dbo].[Wechat_LotteryChecker] " + Wechat_LotteryChecker.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_LotteryChecker>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_LotteryChecker objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_LotteryChecker objects.</returns>
        public static EntityList<Wechat_LotteryChecker> GetWechat_LotteryCheckers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryChecker>(SelectFieldList, "FROM [dbo].[Wechat_LotteryChecker]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_LotteryChecker objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_LotteryChecker objects.</returns>
        public static EntityList<Wechat_LotteryChecker> GetWechat_LotteryCheckers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryChecker>(SelectFieldList, "FROM [dbo].[Wechat_LotteryChecker]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_LotteryChecker objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_LotteryChecker objects.</returns>
		protected static EntityList<Wechat_LotteryChecker> GetWechat_LotteryCheckers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryCheckers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryChecker objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryChecker objects.</returns>
		protected static EntityList<Wechat_LotteryChecker> GetWechat_LotteryCheckers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryCheckers(string.Empty, where, parameters, Wechat_LotteryChecker.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryChecker objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryChecker objects.</returns>
		protected static EntityList<Wechat_LotteryChecker> GetWechat_LotteryCheckers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryCheckers(prefix, where, parameters, Wechat_LotteryChecker.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryChecker objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryChecker objects.</returns>
		protected static EntityList<Wechat_LotteryChecker> GetWechat_LotteryCheckers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_LotteryCheckers(string.Empty, where, parameters, Wechat_LotteryChecker.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryChecker objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryChecker objects.</returns>
		protected static EntityList<Wechat_LotteryChecker> GetWechat_LotteryCheckers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_LotteryCheckers(prefix, where, parameters, Wechat_LotteryChecker.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryChecker objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_LotteryChecker objects.</returns>
		protected static EntityList<Wechat_LotteryChecker> GetWechat_LotteryCheckers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_LotteryChecker.SelectFieldList + "FROM [dbo].[Wechat_LotteryChecker] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_LotteryChecker>(reader);
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
        protected static EntityList<Wechat_LotteryChecker> GetWechat_LotteryCheckers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryChecker>(SelectFieldList, "FROM [dbo].[Wechat_LotteryChecker] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_LotteryChecker objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LotteryCheckerCount()
        {
            return GetWechat_LotteryCheckerCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_LotteryChecker objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LotteryCheckerCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_LotteryChecker] " + where;

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
		public static partial class Wechat_LotteryChecker_Properties
		{
			public const string ID = "ID";
			public const string ActivityID = "ActivityID";
			public const string UserID = "UserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ActivityID" , "int:"},
    			 {"UserID" , "int:"},
            };
		}
		#endregion
	}
}
