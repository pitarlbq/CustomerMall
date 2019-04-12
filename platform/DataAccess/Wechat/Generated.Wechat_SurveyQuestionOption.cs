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
	/// This object represents the properties and methods of a Wechat_SurveyQuestionOption.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_SurveyQuestionOption 
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
		private int _surveyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int SurveyID
		{
			[DebuggerStepThrough()]
			get { return this._surveyID; }
			set 
			{
				if (this._surveyID != value) 
				{
					this._surveyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SurveyID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _surveyQuestionID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int SurveyQuestionID
		{
			[DebuggerStepThrough()]
			get { return this._surveyQuestionID; }
			set 
			{
				if (this._surveyQuestionID != value) 
				{
					this._surveyQuestionID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SurveyQuestionID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _optionContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OptionContent
		{
			[DebuggerStepThrough()]
			get { return this._optionContent; }
			set 
			{
				if (this._optionContent != value) 
				{
					this._optionContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("OptionContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
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
	[SurveyID] int,
	[SurveyQuestionID] int,
	[OptionContent] nvarchar(500),
	[SortOrder] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_SurveyQuestionOption] (
	[Wechat_SurveyQuestionOption].[SurveyID],
	[Wechat_SurveyQuestionOption].[SurveyQuestionID],
	[Wechat_SurveyQuestionOption].[OptionContent],
	[Wechat_SurveyQuestionOption].[SortOrder],
	[Wechat_SurveyQuestionOption].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[SurveyID],
	INSERTED.[SurveyQuestionID],
	INSERTED.[OptionContent],
	INSERTED.[SortOrder],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@SurveyID,
	@SurveyQuestionID,
	@OptionContent,
	@SortOrder,
	@AddTime 
); 

SELECT 
	[ID],
	[SurveyID],
	[SurveyQuestionID],
	[OptionContent],
	[SortOrder],
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
	[SurveyID] int,
	[SurveyQuestionID] int,
	[OptionContent] nvarchar(500),
	[SortOrder] int,
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_SurveyQuestionOption] SET 
	[Wechat_SurveyQuestionOption].[SurveyID] = @SurveyID,
	[Wechat_SurveyQuestionOption].[SurveyQuestionID] = @SurveyQuestionID,
	[Wechat_SurveyQuestionOption].[OptionContent] = @OptionContent,
	[Wechat_SurveyQuestionOption].[SortOrder] = @SortOrder,
	[Wechat_SurveyQuestionOption].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[SurveyID],
	INSERTED.[SurveyQuestionID],
	INSERTED.[OptionContent],
	INSERTED.[SortOrder],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_SurveyQuestionOption].[ID] = @ID

SELECT 
	[ID],
	[SurveyID],
	[SurveyQuestionID],
	[OptionContent],
	[SortOrder],
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
DELETE FROM [dbo].[Wechat_SurveyQuestionOption]
WHERE 
	[Wechat_SurveyQuestionOption].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_SurveyQuestionOption() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_SurveyQuestionOption(this.ID));
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
	[Wechat_SurveyQuestionOption].[ID],
	[Wechat_SurveyQuestionOption].[SurveyID],
	[Wechat_SurveyQuestionOption].[SurveyQuestionID],
	[Wechat_SurveyQuestionOption].[OptionContent],
	[Wechat_SurveyQuestionOption].[SortOrder],
	[Wechat_SurveyQuestionOption].[AddTime]
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
                return "Wechat_SurveyQuestionOption";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_SurveyQuestionOption into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="surveyID">surveyID</param>
		/// <param name="surveyQuestionID">surveyQuestionID</param>
		/// <param name="optionContent">optionContent</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		public static void InsertWechat_SurveyQuestionOption(int @surveyID, int @surveyQuestionID, string @optionContent, int @sortOrder, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_SurveyQuestionOption(@surveyID, @surveyQuestionID, @optionContent, @sortOrder, @addTime, helper);
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
		/// Insert a Wechat_SurveyQuestionOption into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="surveyID">surveyID</param>
		/// <param name="surveyQuestionID">surveyQuestionID</param>
		/// <param name="optionContent">optionContent</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_SurveyQuestionOption(int @surveyID, int @surveyQuestionID, string @optionContent, int @sortOrder, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SurveyID] int,
	[SurveyQuestionID] int,
	[OptionContent] nvarchar(500),
	[SortOrder] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_SurveyQuestionOption] (
	[Wechat_SurveyQuestionOption].[SurveyID],
	[Wechat_SurveyQuestionOption].[SurveyQuestionID],
	[Wechat_SurveyQuestionOption].[OptionContent],
	[Wechat_SurveyQuestionOption].[SortOrder],
	[Wechat_SurveyQuestionOption].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[SurveyID],
	INSERTED.[SurveyQuestionID],
	INSERTED.[OptionContent],
	INSERTED.[SortOrder],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@SurveyID,
	@SurveyQuestionID,
	@OptionContent,
	@SortOrder,
	@AddTime 
); 

SELECT 
	[ID],
	[SurveyID],
	[SurveyQuestionID],
	[OptionContent],
	[SortOrder],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@SurveyID", EntityBase.GetDatabaseValue(@surveyID)));
			parameters.Add(new SqlParameter("@SurveyQuestionID", EntityBase.GetDatabaseValue(@surveyQuestionID)));
			parameters.Add(new SqlParameter("@OptionContent", EntityBase.GetDatabaseValue(@optionContent)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_SurveyQuestionOption into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="surveyID">surveyID</param>
		/// <param name="surveyQuestionID">surveyQuestionID</param>
		/// <param name="optionContent">optionContent</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateWechat_SurveyQuestionOption(int @iD, int @surveyID, int @surveyQuestionID, string @optionContent, int @sortOrder, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_SurveyQuestionOption(@iD, @surveyID, @surveyQuestionID, @optionContent, @sortOrder, @addTime, helper);
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
		/// Updates a Wechat_SurveyQuestionOption into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="surveyID">surveyID</param>
		/// <param name="surveyQuestionID">surveyQuestionID</param>
		/// <param name="optionContent">optionContent</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_SurveyQuestionOption(int @iD, int @surveyID, int @surveyQuestionID, string @optionContent, int @sortOrder, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SurveyID] int,
	[SurveyQuestionID] int,
	[OptionContent] nvarchar(500),
	[SortOrder] int,
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_SurveyQuestionOption] SET 
	[Wechat_SurveyQuestionOption].[SurveyID] = @SurveyID,
	[Wechat_SurveyQuestionOption].[SurveyQuestionID] = @SurveyQuestionID,
	[Wechat_SurveyQuestionOption].[OptionContent] = @OptionContent,
	[Wechat_SurveyQuestionOption].[SortOrder] = @SortOrder,
	[Wechat_SurveyQuestionOption].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[SurveyID],
	INSERTED.[SurveyQuestionID],
	INSERTED.[OptionContent],
	INSERTED.[SortOrder],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_SurveyQuestionOption].[ID] = @ID

SELECT 
	[ID],
	[SurveyID],
	[SurveyQuestionID],
	[OptionContent],
	[SortOrder],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SurveyID", EntityBase.GetDatabaseValue(@surveyID)));
			parameters.Add(new SqlParameter("@SurveyQuestionID", EntityBase.GetDatabaseValue(@surveyQuestionID)));
			parameters.Add(new SqlParameter("@OptionContent", EntityBase.GetDatabaseValue(@optionContent)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_SurveyQuestionOption from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_SurveyQuestionOption(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_SurveyQuestionOption(@iD, helper);
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
		/// Deletes a Wechat_SurveyQuestionOption from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_SurveyQuestionOption(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_SurveyQuestionOption]
WHERE 
	[Wechat_SurveyQuestionOption].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_SurveyQuestionOption object.
		/// </summary>
		/// <returns>The newly created Wechat_SurveyQuestionOption object.</returns>
		public static Wechat_SurveyQuestionOption CreateWechat_SurveyQuestionOption()
		{
			return InitializeNew<Wechat_SurveyQuestionOption>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_SurveyQuestionOption by a Wechat_SurveyQuestionOption's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_SurveyQuestionOption</returns>
		public static Wechat_SurveyQuestionOption GetWechat_SurveyQuestionOption(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_SurveyQuestionOption.SelectFieldList + @"
FROM [dbo].[Wechat_SurveyQuestionOption] 
WHERE 
	[Wechat_SurveyQuestionOption].[ID] = @ID " + Wechat_SurveyQuestionOption.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_SurveyQuestionOption>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_SurveyQuestionOption by a Wechat_SurveyQuestionOption's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_SurveyQuestionOption</returns>
		public static Wechat_SurveyQuestionOption GetWechat_SurveyQuestionOption(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_SurveyQuestionOption.SelectFieldList + @"
FROM [dbo].[Wechat_SurveyQuestionOption] 
WHERE 
	[Wechat_SurveyQuestionOption].[ID] = @ID " + Wechat_SurveyQuestionOption.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_SurveyQuestionOption>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestionOption objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_SurveyQuestionOption objects.</returns>
		public static EntityList<Wechat_SurveyQuestionOption> GetWechat_SurveyQuestionOptions()
		{
			string commandText = @"
SELECT " + Wechat_SurveyQuestionOption.SelectFieldList + "FROM [dbo].[Wechat_SurveyQuestionOption] " + Wechat_SurveyQuestionOption.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_SurveyQuestionOption>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_SurveyQuestionOption objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_SurveyQuestionOption objects.</returns>
        public static EntityList<Wechat_SurveyQuestionOption> GetWechat_SurveyQuestionOptions(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyQuestionOption>(SelectFieldList, "FROM [dbo].[Wechat_SurveyQuestionOption]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_SurveyQuestionOption objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_SurveyQuestionOption objects.</returns>
        public static EntityList<Wechat_SurveyQuestionOption> GetWechat_SurveyQuestionOptions(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyQuestionOption>(SelectFieldList, "FROM [dbo].[Wechat_SurveyQuestionOption]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestionOption objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestionOption objects.</returns>
		protected static EntityList<Wechat_SurveyQuestionOption> GetWechat_SurveyQuestionOptions(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyQuestionOptions(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestionOption objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestionOption objects.</returns>
		protected static EntityList<Wechat_SurveyQuestionOption> GetWechat_SurveyQuestionOptions(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyQuestionOptions(string.Empty, where, parameters, Wechat_SurveyQuestionOption.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestionOption objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestionOption objects.</returns>
		protected static EntityList<Wechat_SurveyQuestionOption> GetWechat_SurveyQuestionOptions(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyQuestionOptions(prefix, where, parameters, Wechat_SurveyQuestionOption.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestionOption objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestionOption objects.</returns>
		protected static EntityList<Wechat_SurveyQuestionOption> GetWechat_SurveyQuestionOptions(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_SurveyQuestionOptions(string.Empty, where, parameters, Wechat_SurveyQuestionOption.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestionOption objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestionOption objects.</returns>
		protected static EntityList<Wechat_SurveyQuestionOption> GetWechat_SurveyQuestionOptions(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_SurveyQuestionOptions(prefix, where, parameters, Wechat_SurveyQuestionOption.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestionOption objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestionOption objects.</returns>
		protected static EntityList<Wechat_SurveyQuestionOption> GetWechat_SurveyQuestionOptions(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_SurveyQuestionOption.SelectFieldList + "FROM [dbo].[Wechat_SurveyQuestionOption] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_SurveyQuestionOption>(reader);
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
        protected static EntityList<Wechat_SurveyQuestionOption> GetWechat_SurveyQuestionOptions(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyQuestionOption>(SelectFieldList, "FROM [dbo].[Wechat_SurveyQuestionOption] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_SurveyQuestionOption objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_SurveyQuestionOptionCount()
        {
            return GetWechat_SurveyQuestionOptionCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_SurveyQuestionOption objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_SurveyQuestionOptionCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_SurveyQuestionOption] " + where;

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
		public static partial class Wechat_SurveyQuestionOption_Properties
		{
			public const string ID = "ID";
			public const string SurveyID = "SurveyID";
			public const string SurveyQuestionID = "SurveyQuestionID";
			public const string OptionContent = "OptionContent";
			public const string SortOrder = "SortOrder";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SurveyID" , "int:"},
    			 {"SurveyQuestionID" , "int:"},
    			 {"OptionContent" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
