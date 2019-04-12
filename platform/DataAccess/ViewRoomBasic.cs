using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ViewRoomBasic.
    /// </summary>
    public partial class ViewRoomBasic : EntityBaseReadOnly
    {
        #region APP Methods
        public static ViewRoomBasic[] GetViewRoomBasicListByUserID(User user, bool IncludeRelation = true, string PhoneNumber = "")
        {
            var phone_list = RoomPhoneRelation.GetRoomPhoneRelationsByPhone(PhoneNumber, uid: user.FinalUserID);
            Mall_UserProject.Insert_UserProjectList(phone_list, user);
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[isParent]=0");
            List<string> cmdlist = new List<string>();
            string cmdwhere = " and [UserID]=@UserID and isnull([IsDisable],0)=0";
            cmdlist.Add("[RoomID] in (select [ProjectID] from [Mall_UserProject] where 1=1 " + cmdwhere + ")");
            if (IncludeRelation)
            {
                cmdlist.Add("[RoomID] in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID] in (select [ProjectID] from [Mall_UserProject] where 1=1 " + cmdwhere + ")))");
            }
            conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            parameters.Add(new SqlParameter("@UserID", user.FinalUserID));
            ViewRoomBasic[] list = new ViewRoomBasic[] { };
            list = GetList<ViewRoomBasic>("select * from [ViewRoomBasic] where  " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder] asc", parameters).ToArray();
            return list;
        }
        #endregion
        public static ViewRoomBasic[] GetViewRoomBasicListByKeywords(int ProjectID, int RoomID, string Keywords, long startRowIndex, int pageSize, out long totalRows)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([isParent],0)=0");
            if (ProjectID > 0)
            {
                conditions.Add("[AllParentID] like '%," + ProjectID + ",%'");
            }
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([Name] like @Keywords or [RelationName] like @Keywords or [RelatePhoneNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[ViewRoomBasic].* ";
            string Statement = " from [ViewRoomBasic] where " + string.Join(" and ", conditions.ToArray());
            ViewRoomBasic[] list = new ViewRoomBasic[] { };
            list = GetList<ViewRoomBasic>(fieldList, Statement, parameters, "order by DefaultOrder asc", startRowIndex, pageSize, out totalRows).ToArray();
            return list;
        }
        public static ViewRoomBasic[] GetRoomBasicListByOpenID(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[isParent]=0");
            conditions.Add("([RoomID] in (select [ProjectID] from [WechatUser_Project] where [OpenID]=@OpenID) or [RoomID] in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID] in (select [ProjectID] from [WechatUser_Project] where [OpenID]=@OpenID))))");
            parameters.Add(new SqlParameter("@OpenID", OpenID));
            ViewRoomBasic[] list = new ViewRoomBasic[] { };
            list = GetList<ViewRoomBasic>("select * from [ViewRoomBasic] where  " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder] asc", parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetProjectDetailsGridByRoomID(int RoomID, bool loadIn, string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RoomID]=@RoomID");
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            string table = string.Empty;
            string cmdwhere = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                cmdwhere += " and ([Name] like @Keywords or [PName] like @Keywords)";
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (loadIn)
            {
                table = @"(select * from [ViewRoomBasic] where [RoomID] in (select RoomID from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where " + string.Join(" and ", conditions.ToArray()) + ")) and [RoomID] in(select [ID] from [Project] where [isParent]=0) " + cmdwhere + ") [ViewProjectRelation]";
            }
            else
            {
                table = @"(select * from [ViewRoomBasic] where [RoomID] not in (select RoomID from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where " + string.Join(" and ", conditions.ToArray()) + ")) and [RoomID] in(select [ID] from [Project] where [isParent]=0)" + cmdwhere + ") [ViewProjectRelation]";
            }

            string fieldList = "[ViewProjectRelation].* ";
            string Statement = " from " + table;
            ViewRoomBasic[] list = new ViewRoomBasic[] { };
            list = GetList<ViewRoomBasic>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewRoomBasic GetViewRoomBasicByRoomID(int RoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([isParent],0)=0");
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            return GetOne<ViewRoomBasic>("select top 1 * from [ViewRoomBasic] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static ViewRoomBasic GetViewRoomBasicByPrintID(int PrintID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([isParent],0)=0");
            conditions.Add("[RoomID] in (select [RoomID] from [RoomFeeHistory] where [PrintID]=@PrintID)");
            parameters.Add(new SqlParameter("@PrintID", PrintID));
            return GetOne<ViewRoomBasic>("select top 1 * from [ViewRoomBasic] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static ViewRoomBasic[] GetViewRoomBasicListByRoomIDArry(List<int> RoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([isParent],0)=0");
            if (RoomID.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomID.ToArray()) + ")");
            }
            return GetList<ViewRoomBasic>("select * from [ViewRoomBasic] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static string GetSearchConditions(List<string> SearchAreas, string keyword)
        {
            string cmd = string.Empty;
            for (int i = 0; i < SearchAreas.Count; i++)
            {
                if (i == 0)
                {
                    cmd += "[" + SearchAreas[i] + "] like '%" + keyword + "%'";
                }
                else
                {
                    cmd += " or [" + SearchAreas[i] + "] like '%" + keyword + "%'";
                }
            }
            cmd += " or [RoomID] in (select [RoomID] from [RoomPhoneRelation] where [RelatePhoneNumber] like '%" + keyword + "%')";
            var config = new Utility.SiteConfig();
            if (config.IsMallOn)
            {
                cmd += " or [RoomID] in (select [RoomID] from [RoomPhoneRelation] where [RelatePhoneNumber] in (select [PhoneNumber] from [User] where [UserID] in (select [UserID] from [Mall_UserFamily] where [PhoneNumber] like '%" + keyword + "%')))";
            }
            return cmd;
        }
        public static Ui.DataGrid GetRoomBasicListByKeywords(List<int> RoomIDList, List<int> ProjectIDList, string RoomOwner, string OwnerPhone, string Keywords, List<string> SearchAreas, string orderBy, long startRowIndex, int pageSize, bool canexport = false)
        {
            return GetRoomBasicListByKeywords(RoomIDList, ProjectIDList, RoomOwner, OwnerPhone, Keywords, SearchAreas, orderBy, startRowIndex, pageSize, string.Empty, int.MinValue, canexport: canexport);
        }
        public static Ui.DataGrid GetRoomBasicListByKeywords(List<int> RoomIDList, List<int> ProjectIDList, string RoomOwner, string OwnerPhone, string Keywords, List<string> SearchAreas, string orderBy, long startRowIndex, int pageSize, string OpenID, int ConnectStatus, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([isParent],0)=0");
            if (!string.IsNullOrEmpty(OpenID))
            {
                if (ConnectStatus > int.MinValue)
                {
                    if (ConnectStatus == 1)
                    {
                        conditions.Add("[RoomID] in (select [ProjectID] from [WechatUser_Project] where OpenID=@OpenID)");
                        parameters.Add(new SqlParameter("@OpenID", OpenID));
                    }
                    else if (ConnectStatus == 0)
                    {
                        conditions.Add("[RoomID] not in (select [ProjectID] from [WechatUser_Project] where OpenID=@OpenID)");
                        parameters.Add(new SqlParameter("@OpenID", OpenID));
                    }
                }
            }
            #region 关键字查询
            string cmd = string.Empty;

            if (!string.IsNullOrEmpty(Keywords))
            {
                cmd += "  and  (" + GetSearchConditions(SearchAreas, Keywords) + ")";
            }
            #endregion
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [RoomID] =" + ProjectID + ")");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(RoomOwner))
            {
                conditions.Add("[RoomOwner]=@RoomOwner");
                parameters.Add(new SqlParameter("@RoomOwner", RoomOwner));
            }
            if (!string.IsNullOrEmpty(OwnerPhone))
            {
                conditions.Add("[OwnerPhone]=@OwnerPhone");
                parameters.Add(new SqlParameter("@OwnerPhone", OwnerPhone));
            }
            string fieldList = "[ViewRoomBasic].*";
            string Statement = " from [ViewRoomBasic] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            ViewRoomBasic[] list = new ViewRoomBasic[] { };
            var phoneList = new RoomPhoneRelation[] { };
            int MinRoomID = 0;
            int MaxRoomID = 0;
            if (canexport)
            {
                list = GetList<ViewRoomBasic>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                if (list.Length > 0)
                {
                    MinRoomID = list.Min(p => p.RoomID);
                    MaxRoomID = list.Max(p => p.RoomID);
                }
                phoneList = RoomPhoneRelation.GetRoomPhoneRelationListByMinMaxRoomID(MinRoomID, MaxRoomID);
            }
            else
            {
                list = GetList<ViewRoomBasic>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
                if (list.Length > 0)
                {
                    MinRoomID = list.Min(p => p.RoomID);
                    MaxRoomID = list.Max(p => p.RoomID);
                }
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            var fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString()).Where(p => p.IsShown).ToArray();

            var contentlist = Foresight.DataAccess.RoomBasicField.GetRoomBasicFieldsByRoomIDList(MinRoomID, MaxRoomID);

            var results = list.Select(p =>
            {
                var dic = p.ToJsonObject(ignoreDBColumn: false);
                if (phoneList.Length > 0)
                {
                    var myPhoneList = phoneList.Where(q => q.RoomID == p.RoomID).OrderByDescending(q => q.IsDefault).ThenBy(q => q.ID).ToArray();
                    if (myPhoneList.Length > 0)
                    {
                        var strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.RelationName)).Select(q => q.RelationName).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["RelationName"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.RelationTypeDesc)).Select(q => q.RelationTypeDesc).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["RelationTypeDesc"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.RelatePhoneNumber)).Select(q => q.RelatePhoneNumber).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["RelatePhoneNumber"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.IDCardTypeDesc)).Select(q => q.IDCardTypeDesc).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["IDCardTypeDesc"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.RelationIDCard)).Select(q => q.RelationIDCard).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["RelationIDCard"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.BirthdayDesc)).Select(q => q.BirthdayDesc).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["Birthday"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.EmailAddress)).Select(q => q.EmailAddress).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["EmailAddress"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.HomeAddress)).Select(q => q.HomeAddress).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["HomeAddress"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.OfficeAddress)).Select(q => q.OfficeAddress).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["OfficeAddress"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.BankAccountName)).Select(q => q.BankAccountName).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["BankAccountName"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.BankAccountNo)).Select(q => q.BankAccountNo).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["BankAccountNo"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.CustomOne)).Select(q => q.CustomOne).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["RelateCustomOne"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.CustomTwo)).Select(q => q.CustomTwo).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["RelateCustomTwo"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.CustomThree)).Select(q => q.CustomThree).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["RelateCustomThree"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.CustomFour)).Select(q => q.CustomFour).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["RelateCustomFour"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.Interesting)).Select(q => q.Interesting).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["Interesting"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.ConsumeMore)).Select(q => q.ConsumeMore).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["ConsumeMore"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.BelongTeam)).Select(q => q.BelongTeam).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["BelongTeam"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.OneCardNumber)).Select(q => q.OneCardNumber).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["OneCardNumber"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.ChargeForMan)).Select(q => q.ChargeForMan).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["ChargeForMan"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.IsDefaultDesc)).Select(q => q.IsDefaultDesc).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["IsDefaultDesc"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.IsChargeFeeDesc)).Select(q => q.IsChargeFeeDesc).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["IsChargeFeeDesc"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.RelationPropertyDesc)).Select(q => q.RelationPropertyDesc).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["RelationPropertyDesc"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.CompanyName)).Select(q => q.CompanyName).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["CompanyName"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.IsChargeManDesc)).Select(q => q.IsChargeManDesc).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["IsChargeManDesc"] = string.Join(",", strList);
                        }
                        strList = myPhoneList.Where(q => !string.IsNullOrEmpty(q.Remark)).Select(q => q.Remark).ToArray();
                        if (strList.Length > 0)
                        {
                            dic["RoomPhoneRelationRemark"] = string.Join(",", strList);
                        }
                    }
                }
                
                foreach (var item in fieldlist)
                {
                    var contentmodel = contentlist.FirstOrDefault(q => q.FieldID == item.ID && q.RoomID == p.RoomID);
                    dic[item.FieldName] = contentmodel == null ? "" : contentmodel.FieldContent;
                }
                return dic;
            }).ToList();
            dg.rows = results;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewRoomBasic[] GetRoomBasicListByKeywords(List<int> RoomIDList, List<int> ProjectIDList, string Keywords = "", bool HavingOrder = false)
        {
            return GetRoomBasicListByKeywords(RoomIDList, ProjectIDList, null, null, Keywords, null, HavingOrder: HavingOrder);
        }

        public static ViewRoomBasic[] GetRoomBasicListByKeywords(List<int> RoomIDList, List<int> ProjectIDList, string RoomOwner, string OwnerPhone, string Keywords, List<string> SearchAreas, bool HavingOrder = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([isParent],0)=0");
            if (HavingOrder)
            {
                conditions.Add("[RoomID] in (select [ProjectID] from [Mall_UserProject] where isnull([IsDisable],0)=0 and [UserID] in (select [UserID] from Mall_Order where ProductTypeID!=10))");
            }
            #region 关键字查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(Keywords) && SearchAreas != null)
            {
                string[] keywords = Keywords.Trim().Split(' ');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  (" + GetSearchConditions(SearchAreas, keywords[i]) + ")";
                        }
                        else
                        {
                            cmd += "  (" + GetSearchConditions(SearchAreas, keywords[i]) + "))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and ((" + GetSearchConditions(SearchAreas, keywords[i]) + ") or";
                    }
                    else
                    {
                        cmd += "  (" + GetSearchConditions(SearchAreas, keywords[i]) + ") or ";
                    }
                }
            }
            #endregion
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [RoomID] =" + ProjectID + ")");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(RoomOwner))
            {
                conditions.Add("[RoomOwner]=@RoomOwner");
                parameters.Add(new SqlParameter("@RoomOwner", RoomOwner));
            }
            if (!string.IsNullOrEmpty(OwnerPhone))
            {
                conditions.Add("[OwnerPhone]=@OwnerPhone");
                parameters.Add(new SqlParameter("@OwnerPhone", OwnerPhone));
            }
            ViewRoomBasic[] list = GetList<ViewRoomBasic>("select * from [ViewRoomBasic] where  " + string.Join(" and ", conditions.ToArray()) + cmd + " order by DefaultOrder asc", parameters).ToArray();
            return list;
        }
        public static ViewRoomBasic[] GetViewRoomBasicByRoomIDList(List<int> RoomIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([isParent],0)=0");
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            return GetList<ViewRoomBasic>("select * from [ViewRoomBasic] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Ui.DataGrid GetViewRoomBasicGrid(List<int> ProjectIDList, List<int> RoomIDList, string Keywords, string orderBy, long startRowIndex, int pageSize, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([isParent],0)=0");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[Name] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("[AllParentID] like '%," + ProjectID + ",%'");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = " order by DefaultOrder asc";
            }
            string fieldList = "[ViewRoomBasic].* ";
            string Statement = " from ViewRoomBasic where " + string.Join(" and ", conditions.ToArray());
            ViewRoomBasic[] list = new ViewRoomBasic[] { };
            if (canexport)
            {
                list = GetList<ViewRoomBasic>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ViewRoomBasic>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string RoomStateDesc
        {
            get
            {
                //string typedesc = string.Empty;
                //switch (this.RoomState)
                //{
                //    case 1:
                //        typedesc = "自住";
                //        break;
                //    case 2:
                //        typedesc = "已租";
                //        break;
                //    case 3:
                //        typedesc = "招租";
                //        break;
                //    case 4:
                //        typedesc = "未售";
                //        break;
                //    default:
                //        break;
                //}
                return this.RoomState;
            }
        }
        public string IDCardTypeDesc
        {
            get
            {
                string typedesc = string.Empty;
                switch (this.IDCardType)
                {
                    case 1:
                        typedesc = "身份证";
                        break;
                    case 2:
                        typedesc = "护照";
                        break;
                    case 3:
                        typedesc = "军人证";
                        break;
                    case 4:
                        typedesc = "驾驶证";
                        break;
                    case 5:
                        typedesc = "其他";
                        break;
                    default:
                        break;
                }
                return typedesc;
            }
        }
        public static int GetIDCardType(string desc)
        {
            if (desc.Equals("身份证"))
            {
                return 1;
            }
            if (desc.Equals("护照"))
            {
                return 2;
            }
            if (desc.Equals("军人证"))
            {
                return 3;
            }
            if (desc.Equals("驾驶证"))
            {
                return 4;
            }
            return 5;
        }
        public string IsLockedDesc
        {
            get
            {
                return this.IsLocked ? "否" : "是";
            }
        }
        public string IsDefaultDesc
        {
            get
            {
                if (this.ID < 0)
                {
                    return "是";
                }
                return this.IsDefault ? "是" : "否";
            }
        }
        public string IsChargeFeeDesc
        {
            get
            {
                if (this.ID < 0)
                {
                    return "是";
                }
                return this.IsChargeFee ? "是" : "否";
            }
        }
        public string RelationTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.RelationType))
                {
                    return "";
                }
                return Utility.EnumHelper.GetDescription(typeof(RelationTypeDefine), this.RelationType);
            }
        }
        public string RelationPropertyDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.RelationProperty))
                {
                    return "个人";
                }
                return Utility.EnumHelper.GetDescription(typeof(RelationPropertyDefine), this.RelationProperty);
            }
        }
        public string IsChargeManDesc
        {
            get
            {
                return this.IsChargeMan ? "是" : "否";
            }
        }
    }
    public class ViewRoomBasicDetails : ViewRoomBasic
    {
        [DatabaseColumn("LastEndPoint")]
        public decimal LastEndPoint { get; set; }
        [DatabaseColumn("LastEndTime")]
        public DateTime LastEndTime { get; set; }
        [DatabaseColumn("LastUnitPrice")]
        public decimal LastUnitPrice { get; set; }
        [DatabaseColumn("LastCoefficient")]
        public decimal LastCoefficient { get; set; }
        [DatabaseColumn("TotalUseCount")]
        public decimal TotalUseCount { get; set; }
        [DatabaseColumn("ProjectBiao_ID")]
        public int ProjectBiao_ID { get; set; }
        [DatabaseColumn("ProjectBiao_BiaoID")]
        public int ProjectBiao_BiaoID { get; set; }
        [DatabaseColumn("ProjectBiao_BiaoCategory")]
        public string ProjectBiao_BiaoCategory { get; set; }
        [DatabaseColumn("ProjectBiao_BiaoName")]
        public string ProjectBiao_BiaoName { get; set; }
        public static ViewRoomBasicDetails[] GetRoomBasicDetailsListByKeywords(List<int> RoomIDList, List<int> ProjectIDList, string WriteDate, int ChargeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[isParent]=0");
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("[AllParentID] like '%," + ProjectID + ",%'");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            ViewRoomBasicDetails[] list = new ViewRoomBasicDetails[] { };
            parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            parameters.Add(new SqlParameter("@WriteDate", WriteDate));
            list = GetList<ViewRoomBasicDetails>("select *,[Project_Biao].[ID] as ProjectBiao_ID,[Project_Biao].[BiaoID] as ProjectBiao_BiaoID,[Project_Biao].[BiaoCategory] as ProjectBiao_BiaoCategory,[Project_Biao].[BiaoName] as ProjectBiao_BiaoName,(select top 1 [EndPoint] from [ImportFee] where ChargeID=@ChargeID and isnull(ProjectBiaoID,0)=isnull([Project_Biao].ID,0) and CONVERT(varchar(10), [WriteDate], 120)<@WriteDate and RoomID=[ViewRoomBasic].RoomID order by WriteDate desc) as LastEndPoint,(select top 1 [EndTime] from [ImportFee] where ChargeID=@ChargeID and isnull(ProjectBiaoID,0)=isnull([Project_Biao].ID,0) and CONVERT(varchar(10), [WriteDate], 120)<@WriteDate and RoomID=[ViewRoomBasic].RoomID order by WriteDate desc) as LastEndTime,(select top 1 [UnitPrice] from [ImportFee] where ChargeID=@ChargeID and isnull(ProjectBiaoID,0)=isnull([Project_Biao].ID,0) and CONVERT(varchar(10), [WriteDate], 120)<@WriteDate and RoomID=[ViewRoomBasic].RoomID order by WriteDate desc) as LastUnitPrice,(select top 1 [ImportCoefficient] from [ImportFee] where ChargeID=@ChargeID and isnull(ProjectBiaoID,0)=isnull([Project_Biao].ID,0) and CONVERT(varchar(10), [WriteDate], 120)<@WriteDate and RoomID=[ViewRoomBasic].RoomID order by WriteDate desc) as LastCoefficient,(select sum(isnull([TotalPoint],0)) from [ImportFee] where ChargeID=@ChargeID and isnull(ProjectBiaoID,0)=isnull([Project_Biao].ID,0) and CONVERT(varchar(10), [WriteDate], 120)<@WriteDate and RoomID=[ViewRoomBasic].RoomID) as TotalUseCount from [ViewRoomBasic] left join (select * from [Project_Biao] where [BiaoID] in (select [ChargeBiaoID] from [ChargeSummary_Biao] where [ChargeID]=@ChargeID)) as [Project_Biao] on [Project_Biao].ProjectID=[ViewRoomBasic].RoomID where  " + string.Join(" and ", conditions.ToArray()) + " and isnull([Project_Biao].[IsActive],1)=1", parameters).ToArray();
            var ProjectBiaoIDList = list.Where(p => p.ProjectBiao_ID > 0).Select(p => p.ProjectBiao_ID).Distinct().ToList();
            return list;
        }
        public static ViewRoomBasicDetails[] GetRoomBasicDetailsListByBiaoID(List<int> RoomIDList, List<int> ProjectIDList, int BiaoID, string BiaoCategory, string BiaoName, string BiaoGuiGe)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[isParent]=0");
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("[AllParentID] like '%," + ProjectID + ",%'");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            ViewRoomBasicDetails[] list = new ViewRoomBasicDetails[] { };
            parameters.Add(new SqlParameter("@BiaoID", BiaoID));
            string cmdwhere = string.Empty;
            if (!string.IsNullOrEmpty(BiaoCategory))
            {
                parameters.Add(new SqlParameter("@BiaoCategory", BiaoCategory));
                cmdwhere += " and [BiaoCategory]=@BiaoCategory";
            }
            if (!string.IsNullOrEmpty(BiaoName))
            {
                parameters.Add(new SqlParameter("@BiaoName", BiaoName));
                cmdwhere += " and [BiaoName]=@BiaoName";
            }
            if (!string.IsNullOrEmpty(BiaoGuiGe))
            {
                parameters.Add(new SqlParameter("@BiaoGuiGe", BiaoGuiGe));
                cmdwhere += " and [BiaoGuiGe]=@BiaoGuiGe";
            }
            list = GetList<ViewRoomBasicDetails>("select *,(select top 1 ID from [Project_Biao] where [ProjectID]=[ViewRoomBasic].RoomID and [BiaoID]=@BiaoID " + cmdwhere + ") as [ProjectBiao_ID] from [ViewRoomBasic] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
    }
}
