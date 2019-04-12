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
	/// This object represents the properties and methods of a Wechat_SurveyOptionResponse.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_SurveyOptionResponse 
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
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
			set 
			{
				if (this._openID != value) 
				{
					this._openID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenID");
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
		[DataObjectField(false, false, true)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _surveyQuestionOptionID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int SurveyQuestionOptionID
		{
			[DebuggerStepThrough()]
			get { return this._surveyQuestionOptionID; }
			set 
			{
				if (this._surveyQuestionOptionID != value) 
				{
					this._surveyQuestionOptionID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SurveyQuestionOptionID");
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
		private int _surveyQuestionID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private string _responseNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ResponseNote
		{
			[DebuggerStepThrough()]
			get { return this._responseNote; }
			set 
			{
				if (this._responseNote != value) 
				{
					this._responseNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("ResponseNote");
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
	[OpenID] nvarchar(500),
	[UserID] int,
	[SurveyQuestionOptionID] int,
	[AddTime] datetime,
	[SurveyQuestionID] int,
	[ResponseNote] ntext
);

INSERT INTO [dbo].[Wechat_SurveyOptionResponse] (
	[Wechat_SurveyOptionResponse].[OpenID],
	[Wechat_SurveyOptionResponse].[UserID],
	[Wechat_SurveyOptionResponse].[SurveyQuestionOptionID],
	[Wechat_SurveyOptionResponse].[AddTime],
	[Wechat_SurveyOptionResponse].[SurveyQuestionID],
	[Wechat_SurveyOptionResponse].[ResponseNote]
) 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[SurveyQuestionOptionID],
	INSERTED.[AddTime],
	INSERTED.[SurveyQuestionID],
	INSERTED.[ResponseNote]
into @table
VALUES ( 
	@OpenID,
	@UserID,
	@SurveyQuestionOptionID,
	@AddTime,
	@SurveyQuestionID,
	@ResponseNote 
); 

SELECT 
	[ID],
	[OpenID],
	[UserID],
	[SurveyQuestionOptionID],
	[AddTime],
	[SurveyQuestionID],
	[ResponseNote] 
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
	[OpenID] nvarchar(500),
	[UserID] int,
	[SurveyQuestionOptionID] int,
	[AddTime] datetime,
	[SurveyQuestionID] int,
	[ResponseNote] ntext
);

UPDATE [dbo].[Wechat_SurveyOptionResponse] SET 
	[Wechat_SurveyOptionResponse].[OpenID] = @OpenID,
	[Wechat_SurveyOptionResponse].[UserID] = @UserID,
	[Wechat_SurveyOptionResponse].[SurveyQuestionOptionID] = @SurveyQuestionOptionID,
	[Wechat_SurveyOptionResponse].[AddTime] = @AddTime,
	[Wechat_SurveyOptionResponse].[SurveyQuestionID] = @SurveyQuestionID,
	[Wechat_SurveyOptionResponse].[ResponseNote] = @ResponseNote 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[SurveyQuestionOptionID],
	INSERTED.[AddTime],
	INSERTED.[SurveyQuestionID],
	INSERTED.[ResponseNote]
into @table
WHERE 
	[Wechat_SurveyOptionResponse].[ID] = @ID

SELECT 
	[ID],
	[OpenID],
	[UserID],
	[SurveyQuestionOptionID],
	[AddTime],
	[SurveyQuestionID],
	[ResponseNote] 
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
DELETE FROM [dbo].[Wechat_SurveyOptionResponse]
WHERE 
	[Wechat_SurveyOptionResponse].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_SurveyOptionResponse() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_SurveyOptionResponse(this.ID));
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
	[Wechat_SurveyOptionResponse].[ID],
	[Wechat_SurveyOptionResponse].[OpenID],
	[Wechat_SurveyOptionResponse].[UserID],
	[Wechat_SurveyOptionResponse].[SurveyQuestionOptionID],
	[Wechat_SurveyOptionResponse].[AddTime],
	[Wechat_SurveyOptionResponse].[SurveyQuestionID],
	[Wechat_SurveyOptionResponse].[ResponseNote]
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
                return "Wechat_SurveyOptionResponse";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_SurveyOptionResponse into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="surveyQuestionOptionID">surveyQuestionOptionID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="surveyQuestionID">surveyQuestionID</param>
		/// <param name="responseNote">responseNote</param>
		public static void InsertWechat_SurveyOptionResponse(string @openID, int @userID, int @surveyQuestionOptionID, DateTime @addTime, int @surveyQuestionID, string @responseNote)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_SurveyOptionResponse(@openID, @userID, @surveyQuestionOptionID, @addTime, @surveyQuestionID, @responseNote, helper);
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
		/// Insert a Wechat_SurveyOptionResponse into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="surveyQuestionOptionID">surveyQuestionOptionID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="surveyQuestionID">surveyQuestionID</param>
		/// <param name="responseNote">responseNote</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_SurveyOptionResponse(string @openID, int @userID, int @surveyQuestionOptionID, DateTime @addTime, int @surveyQuestionID, string @responseNote, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OpenID] nvarchar(500),
	[UserID] int,
	[SurveyQuestionOptionID] int,
	[AddTime] datetime,
	[SurveyQuestionID] int,
	[ResponseNote] ntext
);

INSERT INTO [dbo].[Wechat_SurveyOptionResponse] (
	[Wechat_SurveyOptionResponse].[OpenID],
	[Wechat_SurveyOptionResponse].[UserID],
	[Wechat_SurveyOptionResponse].[SurveyQuestionOptionID],
	[Wechat_SurveyOptionResponse].[AddTime],
	[Wechat_SurveyOptionResponse].[SurveyQuestionID],
	[Wechat_SurveyOptionResponse].[ResponseNote]
) 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[SurveyQuestionOptionID],
	INSERTED.[AddTime],
	INSERTED.[SurveyQuestionID],
	INSERTED.[ResponseNote]
into @table
VALUES ( 
	@OpenID,
	@UserID,
	@SurveyQuestionOptionID,
	@AddTime,
	@SurveyQuestionID,
	@ResponseNote 
); 

SELECT 
	[ID],
	[OpenID],
	[UserID],
	[SurveyQuestionOptionID],
	[AddTime],
	[SurveyQuestionID],
	[ResponseNote] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@SurveyQuestionOptionID", EntityBase.GetDatabaseValue(@surveyQuestionOptionID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SurveyQuestionID", EntityBase.GetDatabaseValue(@surveyQuestionID)));
			parameters.Add(new SqlParameter("@ResponseNote", EntityBase.GetDatabaseValue(@responseNote)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_SurveyOptionResponse into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="surveyQuestionOptionID">surveyQuestionOptionID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="surveyQuestionID">surveyQuestionID</param>
		/// <param name="responseNote">responseNote</param>
		public static void UpdateWechat_SurveyOptionResponse(int @iD, string @openID, int @userID, int @surveyQuestionOptionID, DateTime @addTime, int @surveyQuestionID, string @responseNote)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_SurveyOptionResponse(@iD, @openID, @userID, @surveyQuestionOptionID, @addTime, @surveyQuestionID, @responseNote, helper);
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
		/// Updates a Wechat_SurveyOptionResponse into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="surveyQuestionOptionID">surveyQuestionOptionID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="surveyQuestionID">surveyQuestionID</param>
		/// <param name="responseNote">responseNote</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_SurveyOptionResponse(int @iD, string @openID, int @userID, int @surveyQuestionOptionID, DateTime @addTime, int @surveyQuestionID, string @responseNote, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OpenID] nvarchar(500),
	[UserID] int,
	[SurveyQuestionOptionID] int,
	[AddTime] datetime,
	[SurveyQuestionID] int,
	[ResponseNote] ntext
);

UPDATE [dbo].[Wechat_SurveyOptionResponse] SET 
	[Wechat_SurveyOptionResponse].[OpenID] = @OpenID,
	[Wechat_SurveyOptionResponse].[UserID] = @UserID,
	[Wechat_SurveyOptionResponse].[SurveyQuestionOptionID] = @SurveyQuestionOptionID,
	[Wechat_SurveyOptionResponse].[AddTime] = @AddTime,
	[Wechat_SurveyOptionResponse].[SurveyQuestionID] = @SurveyQuestionID,
	[Wechat_SurveyOptionResponse].[ResponseNote] = @ResponseNote 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[SurveyQuestionOptionID],
	INSERTED.[AddTime],
	INSERTED.[SurveyQuestionID],
	INSERTED.[ResponseNote]
into @table
WHERE 
	[Wechat_SurveyOptionResponse].[ID] = @ID

SELECT 
	[ID],
	[OpenID],
	[UserID],
	[SurveyQuestionOptionID],
	[AddTime],
	[SurveyQuestionID],
	[ResponseNote] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@SurveyQuestionOptionID", EntityBase.GetDatabaseValue(@surveyQuestionOptionID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SurveyQuestionID", EntityBase.GetDatabaseValue(@surveyQuestionID)));
			parameters.Add(new SqlParameter("@ResponseNote", EntityBase.GetDatabaseValue(@responseNote)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_SurveyOptionResponse from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_SurveyOptionResponse(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_SurveyOptionResponse(@iD, helper);
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
		/// Deletes a Wechat_SurveyOptionResponse from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_SurveyOptionResponse(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_SurveyOptionResponse]
WHERE 
	[Wechat_SurveyOptionResponse].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_SurveyOptionResponse object.
		/// </summary>
		/// <returns>The newly created Wechat_SurveyOptionResponse object.</returns>
		public static Wechat_SurveyOptionResponse CreateWechat_SurveyOptionResponse()
		{
			return InitializeNew<Wechat_SurveyOptionResponse>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_SurveyOptionResponse by a Wechat_SurveyOptionResponse's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_SurveyOptionResponse</returns>
		public static Wechat_SurveyOptionResponse GetWechat_SurveyOptionResponse(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_SurveyOptionResponse.SelectFieldList + @"
FROM [dbo].[Wechat_SurveyOptionResponse] 
WHERE 
	[Wechat_SurveyOptionResponse].[ID] = @ID " + Wechat_SurveyOptionResponse.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_SurveyOptionResponse>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_SurveyOptionResponse by a Wechat_SurveyOptionResponse's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_SurveyOptionResponse</returns>
		public static Wechat_SurveyOptionResponse GetWechat_SurveyOptionResponse(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_SurveyOptionResponse.SelectFieldList + @"
FROM [dbo].[Wechat_SurveyOptionResponse] 
WHERE 
	[Wechat_SurveyOptionResponse].[ID] = @ID " + Wechat_SurveyOptionResponse.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_SurveyOptionResponse>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyOptionResponse objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_SurveyOptionResponse objects.</returns>
		public static EntityList<Wechat_SurveyOptionResponse> GetWechat_SurveyOptionResponses()
		{
			string commandText = @"
SELECT " + Wechat_SurveyOptionResponse.SelectFieldList + "FROM [dbo].[Wechat_SurveyOptionResponse] " + Wechat_SurveyOptionResponse.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_SurveyOptionResponse>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_SurveyOptionResponse objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_SurveyOptionResponse objects.</returns>
        public static EntityList<Wechat_SurveyOptionResponse> GetWechat_SurveyOptionResponses(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyOptionResponse>(SelectFieldList, "FROM [dbo].[Wechat_SurveyOptionResponse]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_SurveyOptionResponse objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_SurveyOptionResponse objects.</returns>
        public static EntityList<Wechat_SurveyOptionResponse> GetWechat_SurveyOptionResponses(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyOptionResponse>(SelectFieldList, "FROM [dbo].[Wechat_SurveyOptionResponse]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_SurveyOptionResponse objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_SurveyOptionResponse objects.</returns>
		protected static EntityList<Wechat_SurveyOptionResponse> GetWechat_SurveyOptionResponses(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyOptionResponses(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyOptionResponse objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyOptionResponse objects.</returns>
		protected static EntityList<Wechat_SurveyOptionResponse> GetWechat_SurveyOptionResponses(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyOptionResponses(string.Empty, where, parameters, Wechat_SurveyOptionResponse.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyOptionResponse objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyOptionResponse objects.</returns>
		protected static EntityList<Wechat_SurveyOptionResponse> GetWechat_SurveyOptionResponses(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyOptionResponses(prefix, where, parameters, Wechat_SurveyOptionResponse.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyOptionResponse objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyOptionResponse objects.</returns>
		protected static EntityList<Wechat_SurveyOptionResponse> GetWechat_SurveyOptionResponses(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_SurveyOptionResponses(string.Empty, where, parameters, Wechat_SurveyOptionResponse.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyOptionResponse objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyOptionResponse objects.</returns>
		protected static EntityList<Wechat_SurveyOptionResponse> GetWechat_SurveyOptionResponses(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_SurveyOptionResponses(prefix, where, parameters, Wechat_SurveyOptionResponse.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyOptionResponse objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_SurveyOptionResponse objects.</returns>
		protected static EntityList<Wechat_SurveyOptionResponse> GetWechat_SurveyOptionResponses(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_SurveyOptionResponse.SelectFieldList + "FROM [dbo].[Wechat_SurveyOptionResponse] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_SurveyOptionResponse>(reader);
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
        protected static EntityList<Wechat_SurveyOptionResponse> GetWechat_SurveyOptionResponses(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyOptionResponse>(SelectFieldList, "FROM [dbo].[Wechat_SurveyOptionResponse] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_SurveyOptionResponse objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_SurveyOptionResponseCount()
        {
            return GetWechat_SurveyOptionResponseCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_SurveyOptionResponse objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_SurveyOptionResponseCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_SurveyOptionResponse] " + where;

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
		public static partial class Wechat_SurveyOptionResponse_Properties
		{
			public const string ID = "ID";
			public const string OpenID = "OpenID";
			public const string UserID = "UserID";
			public const string SurveyQuestionOptionID = "SurveyQuestionOptionID";
			public const string AddTime = "AddTime";
			public const string SurveyQuestionID = "SurveyQuestionID";
			public const string ResponseNote = "ResponseNote";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OpenID" , "string:"},
    			 {"UserID" , "int:"},
    			 {"SurveyQuestionOptionID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"SurveyQuestionID" , "int:"},
    			 {"ResponseNote" , "string:"},
            };
		}
		#endregion
	}
}
