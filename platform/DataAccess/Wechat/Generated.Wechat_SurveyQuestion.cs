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
	/// This object represents the properties and methods of a Wechat_SurveyQuestion.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_SurveyQuestion 
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
		private string _questionContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string QuestionContent
		{
			[DebuggerStepThrough()]
			get { return this._questionContent; }
			set 
			{
				if (this._questionContent != value) 
				{
					this._questionContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("QuestionContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _questionType = int.MinValue;
		/// <summary>
		/// 1-单选 2-多选
		/// </summary>
        [Description("1-单选 2-多选")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int QuestionType
		{
			[DebuggerStepThrough()]
			get { return this._questionType; }
			set 
			{
				if (this._questionType != value) 
				{
					this._questionType = value;
					this.IsDirty = true;	
					OnPropertyChanged("QuestionType");
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
		[DataObjectField(false, false, true)]
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
		[DataObjectField(false, false, true)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _coverImg = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CoverImg
		{
			[DebuggerStepThrough()]
			get { return this._coverImg; }
			set 
			{
				if (this._coverImg != value) 
				{
					this._coverImg = value;
					this.IsDirty = true;	
					OnPropertyChanged("CoverImg");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _questionDescription = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string QuestionDescription
		{
			[DebuggerStepThrough()]
			get { return this._questionDescription; }
			set 
			{
				if (this._questionDescription != value) 
				{
					this._questionDescription = value;
					this.IsDirty = true;	
					OnPropertyChanged("QuestionDescription");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _questionSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string QuestionSummary
		{
			[DebuggerStepThrough()]
			get { return this._questionSummary; }
			set 
			{
				if (this._questionSummary != value) 
				{
					this._questionSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("QuestionSummary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDisabled = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDisabled
		{
			[DebuggerStepThrough()]
			get { return this._isDisabled; }
			set 
			{
				if (this._isDisabled != value) 
				{
					this._isDisabled = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDisabled");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDeleted = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDeleted
		{
			[DebuggerStepThrough()]
			get { return this._isDeleted; }
			set 
			{
				if (this._isDeleted != value) 
				{
					this._isDeleted = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDeleted");
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
	[QuestionContent] nvarchar(500),
	[QuestionType] int,
	[SortOrder] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[CoverImg] nvarchar(500),
	[QuestionDescription] ntext,
	[QuestionSummary] ntext,
	[IsDisabled] bit,
	[IsDeleted] bit,
	[UserID] int
);

INSERT INTO [dbo].[Wechat_SurveyQuestion] (
	[Wechat_SurveyQuestion].[SurveyID],
	[Wechat_SurveyQuestion].[QuestionContent],
	[Wechat_SurveyQuestion].[QuestionType],
	[Wechat_SurveyQuestion].[SortOrder],
	[Wechat_SurveyQuestion].[AddTime],
	[Wechat_SurveyQuestion].[AddMan],
	[Wechat_SurveyQuestion].[CoverImg],
	[Wechat_SurveyQuestion].[QuestionDescription],
	[Wechat_SurveyQuestion].[QuestionSummary],
	[Wechat_SurveyQuestion].[IsDisabled],
	[Wechat_SurveyQuestion].[IsDeleted],
	[Wechat_SurveyQuestion].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[SurveyID],
	INSERTED.[QuestionContent],
	INSERTED.[QuestionType],
	INSERTED.[SortOrder],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[CoverImg],
	INSERTED.[QuestionDescription],
	INSERTED.[QuestionSummary],
	INSERTED.[IsDisabled],
	INSERTED.[IsDeleted],
	INSERTED.[UserID]
into @table
VALUES ( 
	@SurveyID,
	@QuestionContent,
	@QuestionType,
	@SortOrder,
	@AddTime,
	@AddMan,
	@CoverImg,
	@QuestionDescription,
	@QuestionSummary,
	@IsDisabled,
	@IsDeleted,
	@UserID 
); 

SELECT 
	[ID],
	[SurveyID],
	[QuestionContent],
	[QuestionType],
	[SortOrder],
	[AddTime],
	[AddMan],
	[CoverImg],
	[QuestionDescription],
	[QuestionSummary],
	[IsDisabled],
	[IsDeleted],
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
	[SurveyID] int,
	[QuestionContent] nvarchar(500),
	[QuestionType] int,
	[SortOrder] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[CoverImg] nvarchar(500),
	[QuestionDescription] ntext,
	[QuestionSummary] ntext,
	[IsDisabled] bit,
	[IsDeleted] bit,
	[UserID] int
);

UPDATE [dbo].[Wechat_SurveyQuestion] SET 
	[Wechat_SurveyQuestion].[SurveyID] = @SurveyID,
	[Wechat_SurveyQuestion].[QuestionContent] = @QuestionContent,
	[Wechat_SurveyQuestion].[QuestionType] = @QuestionType,
	[Wechat_SurveyQuestion].[SortOrder] = @SortOrder,
	[Wechat_SurveyQuestion].[AddTime] = @AddTime,
	[Wechat_SurveyQuestion].[AddMan] = @AddMan,
	[Wechat_SurveyQuestion].[CoverImg] = @CoverImg,
	[Wechat_SurveyQuestion].[QuestionDescription] = @QuestionDescription,
	[Wechat_SurveyQuestion].[QuestionSummary] = @QuestionSummary,
	[Wechat_SurveyQuestion].[IsDisabled] = @IsDisabled,
	[Wechat_SurveyQuestion].[IsDeleted] = @IsDeleted,
	[Wechat_SurveyQuestion].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[SurveyID],
	INSERTED.[QuestionContent],
	INSERTED.[QuestionType],
	INSERTED.[SortOrder],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[CoverImg],
	INSERTED.[QuestionDescription],
	INSERTED.[QuestionSummary],
	INSERTED.[IsDisabled],
	INSERTED.[IsDeleted],
	INSERTED.[UserID]
into @table
WHERE 
	[Wechat_SurveyQuestion].[ID] = @ID

SELECT 
	[ID],
	[SurveyID],
	[QuestionContent],
	[QuestionType],
	[SortOrder],
	[AddTime],
	[AddMan],
	[CoverImg],
	[QuestionDescription],
	[QuestionSummary],
	[IsDisabled],
	[IsDeleted],
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
DELETE FROM [dbo].[Wechat_SurveyQuestion]
WHERE 
	[Wechat_SurveyQuestion].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_SurveyQuestion() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_SurveyQuestion(this.ID));
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
	[Wechat_SurveyQuestion].[ID],
	[Wechat_SurveyQuestion].[SurveyID],
	[Wechat_SurveyQuestion].[QuestionContent],
	[Wechat_SurveyQuestion].[QuestionType],
	[Wechat_SurveyQuestion].[SortOrder],
	[Wechat_SurveyQuestion].[AddTime],
	[Wechat_SurveyQuestion].[AddMan],
	[Wechat_SurveyQuestion].[CoverImg],
	[Wechat_SurveyQuestion].[QuestionDescription],
	[Wechat_SurveyQuestion].[QuestionSummary],
	[Wechat_SurveyQuestion].[IsDisabled],
	[Wechat_SurveyQuestion].[IsDeleted],
	[Wechat_SurveyQuestion].[UserID]
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
                return "Wechat_SurveyQuestion";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_SurveyQuestion into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="surveyID">surveyID</param>
		/// <param name="questionContent">questionContent</param>
		/// <param name="questionType">questionType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="questionDescription">questionDescription</param>
		/// <param name="questionSummary">questionSummary</param>
		/// <param name="isDisabled">isDisabled</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="userID">userID</param>
		public static void InsertWechat_SurveyQuestion(int @surveyID, string @questionContent, int @questionType, int @sortOrder, DateTime @addTime, string @addMan, string @coverImg, string @questionDescription, string @questionSummary, bool @isDisabled, bool @isDeleted, int @userID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_SurveyQuestion(@surveyID, @questionContent, @questionType, @sortOrder, @addTime, @addMan, @coverImg, @questionDescription, @questionSummary, @isDisabled, @isDeleted, @userID, helper);
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
		/// Insert a Wechat_SurveyQuestion into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="surveyID">surveyID</param>
		/// <param name="questionContent">questionContent</param>
		/// <param name="questionType">questionType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="questionDescription">questionDescription</param>
		/// <param name="questionSummary">questionSummary</param>
		/// <param name="isDisabled">isDisabled</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_SurveyQuestion(int @surveyID, string @questionContent, int @questionType, int @sortOrder, DateTime @addTime, string @addMan, string @coverImg, string @questionDescription, string @questionSummary, bool @isDisabled, bool @isDeleted, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SurveyID] int,
	[QuestionContent] nvarchar(500),
	[QuestionType] int,
	[SortOrder] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[CoverImg] nvarchar(500),
	[QuestionDescription] ntext,
	[QuestionSummary] ntext,
	[IsDisabled] bit,
	[IsDeleted] bit,
	[UserID] int
);

INSERT INTO [dbo].[Wechat_SurveyQuestion] (
	[Wechat_SurveyQuestion].[SurveyID],
	[Wechat_SurveyQuestion].[QuestionContent],
	[Wechat_SurveyQuestion].[QuestionType],
	[Wechat_SurveyQuestion].[SortOrder],
	[Wechat_SurveyQuestion].[AddTime],
	[Wechat_SurveyQuestion].[AddMan],
	[Wechat_SurveyQuestion].[CoverImg],
	[Wechat_SurveyQuestion].[QuestionDescription],
	[Wechat_SurveyQuestion].[QuestionSummary],
	[Wechat_SurveyQuestion].[IsDisabled],
	[Wechat_SurveyQuestion].[IsDeleted],
	[Wechat_SurveyQuestion].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[SurveyID],
	INSERTED.[QuestionContent],
	INSERTED.[QuestionType],
	INSERTED.[SortOrder],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[CoverImg],
	INSERTED.[QuestionDescription],
	INSERTED.[QuestionSummary],
	INSERTED.[IsDisabled],
	INSERTED.[IsDeleted],
	INSERTED.[UserID]
into @table
VALUES ( 
	@SurveyID,
	@QuestionContent,
	@QuestionType,
	@SortOrder,
	@AddTime,
	@AddMan,
	@CoverImg,
	@QuestionDescription,
	@QuestionSummary,
	@IsDisabled,
	@IsDeleted,
	@UserID 
); 

SELECT 
	[ID],
	[SurveyID],
	[QuestionContent],
	[QuestionType],
	[SortOrder],
	[AddTime],
	[AddMan],
	[CoverImg],
	[QuestionDescription],
	[QuestionSummary],
	[IsDisabled],
	[IsDeleted],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@SurveyID", EntityBase.GetDatabaseValue(@surveyID)));
			parameters.Add(new SqlParameter("@QuestionContent", EntityBase.GetDatabaseValue(@questionContent)));
			parameters.Add(new SqlParameter("@QuestionType", EntityBase.GetDatabaseValue(@questionType)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@CoverImg", EntityBase.GetDatabaseValue(@coverImg)));
			parameters.Add(new SqlParameter("@QuestionDescription", EntityBase.GetDatabaseValue(@questionDescription)));
			parameters.Add(new SqlParameter("@QuestionSummary", EntityBase.GetDatabaseValue(@questionSummary)));
			parameters.Add(new SqlParameter("@IsDisabled", @isDisabled));
			parameters.Add(new SqlParameter("@IsDeleted", @isDeleted));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_SurveyQuestion into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="surveyID">surveyID</param>
		/// <param name="questionContent">questionContent</param>
		/// <param name="questionType">questionType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="questionDescription">questionDescription</param>
		/// <param name="questionSummary">questionSummary</param>
		/// <param name="isDisabled">isDisabled</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="userID">userID</param>
		public static void UpdateWechat_SurveyQuestion(int @iD, int @surveyID, string @questionContent, int @questionType, int @sortOrder, DateTime @addTime, string @addMan, string @coverImg, string @questionDescription, string @questionSummary, bool @isDisabled, bool @isDeleted, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_SurveyQuestion(@iD, @surveyID, @questionContent, @questionType, @sortOrder, @addTime, @addMan, @coverImg, @questionDescription, @questionSummary, @isDisabled, @isDeleted, @userID, helper);
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
		/// Updates a Wechat_SurveyQuestion into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="surveyID">surveyID</param>
		/// <param name="questionContent">questionContent</param>
		/// <param name="questionType">questionType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="questionDescription">questionDescription</param>
		/// <param name="questionSummary">questionSummary</param>
		/// <param name="isDisabled">isDisabled</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_SurveyQuestion(int @iD, int @surveyID, string @questionContent, int @questionType, int @sortOrder, DateTime @addTime, string @addMan, string @coverImg, string @questionDescription, string @questionSummary, bool @isDisabled, bool @isDeleted, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SurveyID] int,
	[QuestionContent] nvarchar(500),
	[QuestionType] int,
	[SortOrder] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[CoverImg] nvarchar(500),
	[QuestionDescription] ntext,
	[QuestionSummary] ntext,
	[IsDisabled] bit,
	[IsDeleted] bit,
	[UserID] int
);

UPDATE [dbo].[Wechat_SurveyQuestion] SET 
	[Wechat_SurveyQuestion].[SurveyID] = @SurveyID,
	[Wechat_SurveyQuestion].[QuestionContent] = @QuestionContent,
	[Wechat_SurveyQuestion].[QuestionType] = @QuestionType,
	[Wechat_SurveyQuestion].[SortOrder] = @SortOrder,
	[Wechat_SurveyQuestion].[AddTime] = @AddTime,
	[Wechat_SurveyQuestion].[AddMan] = @AddMan,
	[Wechat_SurveyQuestion].[CoverImg] = @CoverImg,
	[Wechat_SurveyQuestion].[QuestionDescription] = @QuestionDescription,
	[Wechat_SurveyQuestion].[QuestionSummary] = @QuestionSummary,
	[Wechat_SurveyQuestion].[IsDisabled] = @IsDisabled,
	[Wechat_SurveyQuestion].[IsDeleted] = @IsDeleted,
	[Wechat_SurveyQuestion].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[SurveyID],
	INSERTED.[QuestionContent],
	INSERTED.[QuestionType],
	INSERTED.[SortOrder],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[CoverImg],
	INSERTED.[QuestionDescription],
	INSERTED.[QuestionSummary],
	INSERTED.[IsDisabled],
	INSERTED.[IsDeleted],
	INSERTED.[UserID]
into @table
WHERE 
	[Wechat_SurveyQuestion].[ID] = @ID

SELECT 
	[ID],
	[SurveyID],
	[QuestionContent],
	[QuestionType],
	[SortOrder],
	[AddTime],
	[AddMan],
	[CoverImg],
	[QuestionDescription],
	[QuestionSummary],
	[IsDisabled],
	[IsDeleted],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SurveyID", EntityBase.GetDatabaseValue(@surveyID)));
			parameters.Add(new SqlParameter("@QuestionContent", EntityBase.GetDatabaseValue(@questionContent)));
			parameters.Add(new SqlParameter("@QuestionType", EntityBase.GetDatabaseValue(@questionType)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@CoverImg", EntityBase.GetDatabaseValue(@coverImg)));
			parameters.Add(new SqlParameter("@QuestionDescription", EntityBase.GetDatabaseValue(@questionDescription)));
			parameters.Add(new SqlParameter("@QuestionSummary", EntityBase.GetDatabaseValue(@questionSummary)));
			parameters.Add(new SqlParameter("@IsDisabled", @isDisabled));
			parameters.Add(new SqlParameter("@IsDeleted", @isDeleted));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_SurveyQuestion from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_SurveyQuestion(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_SurveyQuestion(@iD, helper);
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
		/// Deletes a Wechat_SurveyQuestion from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_SurveyQuestion(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_SurveyQuestion]
WHERE 
	[Wechat_SurveyQuestion].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_SurveyQuestion object.
		/// </summary>
		/// <returns>The newly created Wechat_SurveyQuestion object.</returns>
		public static Wechat_SurveyQuestion CreateWechat_SurveyQuestion()
		{
			return InitializeNew<Wechat_SurveyQuestion>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_SurveyQuestion by a Wechat_SurveyQuestion's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_SurveyQuestion</returns>
		public static Wechat_SurveyQuestion GetWechat_SurveyQuestion(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_SurveyQuestion.SelectFieldList + @"
FROM [dbo].[Wechat_SurveyQuestion] 
WHERE 
	[Wechat_SurveyQuestion].[ID] = @ID " + Wechat_SurveyQuestion.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_SurveyQuestion>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_SurveyQuestion by a Wechat_SurveyQuestion's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_SurveyQuestion</returns>
		public static Wechat_SurveyQuestion GetWechat_SurveyQuestion(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_SurveyQuestion.SelectFieldList + @"
FROM [dbo].[Wechat_SurveyQuestion] 
WHERE 
	[Wechat_SurveyQuestion].[ID] = @ID " + Wechat_SurveyQuestion.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_SurveyQuestion>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestion objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_SurveyQuestion objects.</returns>
		public static EntityList<Wechat_SurveyQuestion> GetWechat_SurveyQuestions()
		{
			string commandText = @"
SELECT " + Wechat_SurveyQuestion.SelectFieldList + "FROM [dbo].[Wechat_SurveyQuestion] " + Wechat_SurveyQuestion.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_SurveyQuestion>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_SurveyQuestion objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_SurveyQuestion objects.</returns>
        public static EntityList<Wechat_SurveyQuestion> GetWechat_SurveyQuestions(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyQuestion>(SelectFieldList, "FROM [dbo].[Wechat_SurveyQuestion]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_SurveyQuestion objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_SurveyQuestion objects.</returns>
        public static EntityList<Wechat_SurveyQuestion> GetWechat_SurveyQuestions(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyQuestion>(SelectFieldList, "FROM [dbo].[Wechat_SurveyQuestion]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestion objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestion objects.</returns>
		protected static EntityList<Wechat_SurveyQuestion> GetWechat_SurveyQuestions(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyQuestions(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestion objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestion objects.</returns>
		protected static EntityList<Wechat_SurveyQuestion> GetWechat_SurveyQuestions(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyQuestions(string.Empty, where, parameters, Wechat_SurveyQuestion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestion objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestion objects.</returns>
		protected static EntityList<Wechat_SurveyQuestion> GetWechat_SurveyQuestions(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyQuestions(prefix, where, parameters, Wechat_SurveyQuestion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestion objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestion objects.</returns>
		protected static EntityList<Wechat_SurveyQuestion> GetWechat_SurveyQuestions(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_SurveyQuestions(string.Empty, where, parameters, Wechat_SurveyQuestion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestion objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestion objects.</returns>
		protected static EntityList<Wechat_SurveyQuestion> GetWechat_SurveyQuestions(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_SurveyQuestions(prefix, where, parameters, Wechat_SurveyQuestion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyQuestion objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_SurveyQuestion objects.</returns>
		protected static EntityList<Wechat_SurveyQuestion> GetWechat_SurveyQuestions(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_SurveyQuestion.SelectFieldList + "FROM [dbo].[Wechat_SurveyQuestion] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_SurveyQuestion>(reader);
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
        protected static EntityList<Wechat_SurveyQuestion> GetWechat_SurveyQuestions(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyQuestion>(SelectFieldList, "FROM [dbo].[Wechat_SurveyQuestion] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_SurveyQuestion objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_SurveyQuestionCount()
        {
            return GetWechat_SurveyQuestionCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_SurveyQuestion objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_SurveyQuestionCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_SurveyQuestion] " + where;

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
		public static partial class Wechat_SurveyQuestion_Properties
		{
			public const string ID = "ID";
			public const string SurveyID = "SurveyID";
			public const string QuestionContent = "QuestionContent";
			public const string QuestionType = "QuestionType";
			public const string SortOrder = "SortOrder";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string CoverImg = "CoverImg";
			public const string QuestionDescription = "QuestionDescription";
			public const string QuestionSummary = "QuestionSummary";
			public const string IsDisabled = "IsDisabled";
			public const string IsDeleted = "IsDeleted";
			public const string UserID = "UserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SurveyID" , "int:"},
    			 {"QuestionContent" , "string:"},
    			 {"QuestionType" , "int:1-单选 2-多选"},
    			 {"SortOrder" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"CoverImg" , "string:"},
    			 {"QuestionDescription" , "string:"},
    			 {"QuestionSummary" , "string:"},
    			 {"IsDisabled" , "bool:"},
    			 {"IsDeleted" , "bool:"},
    			 {"UserID" , "int:"},
            };
		}
		#endregion
	}
}
