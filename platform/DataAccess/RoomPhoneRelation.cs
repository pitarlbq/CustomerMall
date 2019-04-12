using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;
using System.ComponentModel;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a RoomPhoneRelation.
    /// </summary>
    public partial class RoomPhoneRelation : EntityBase
    {
        public static RoomPhoneRelation GetDefaultInChargeFeeRoomPhoneRelation(int RoomID, int ContractID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetDefaultInChargeFeeRoomPhoneRelation(RoomID, ContractID, helper);
            }
        }
        public static RoomPhoneRelation GetDefaultInChargeFeeRoomPhoneRelation(int RoomID, int ContractID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ContractID > 0)
            {
                conditions.Add("[ContractID]=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            else if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            RoomPhoneRelation data = GetOne<RoomPhoneRelation>("select * from [RoomPhoneRelation] where [IsChargeFee]=1 and " + string.Join(" and ", conditions.ToArray()), parameters, helper);
            if (data == null)
            {
                data = GetOne<RoomPhoneRelation>("select * from [RoomPhoneRelation] where [IsChargeMan]=1 and " + string.Join(" and ", conditions.ToArray()), parameters, helper);
            }
            return data;
        }
        public static RoomPhoneRelation[] GetDefaultInChargeFeeRoomPhoneRelationList(List<int> RoomFeeIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomFeeIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (select RoomID from RoomFee where ID in (" + string.Join(",", RoomFeeIDList.ToArray()) + "))");
            }
            return GetList<RoomPhoneRelation>("SELECT * FROM [RoomPhoneRelation] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomPhoneRelation[] GetRoomPhoneRelationsByRoomID(int RoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            RoomPhoneRelation[] list = GetList<RoomPhoneRelation>("SELECT * FROM [RoomPhoneRelation] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static RoomPhoneRelation GetRoomPhoneRelationsByRoomIDAndPhone(int RoomID, string Phone)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetRoomPhoneRelationsByRoomIDAndPhone(RoomID, Phone, helper);
            }
        }
        public static RoomPhoneRelation GetRoomPhoneRelationsByRoomIDAndPhone(int RoomID, string Phone, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            if (!string.IsNullOrEmpty(Phone))
            {
                conditions.Add("[RelatePhoneNumber]=@RelatePhoneNumber");
                parameters.Add(new SqlParameter("@RelatePhoneNumber", Phone));
            }
            RoomPhoneRelation relation = GetOne<RoomPhoneRelation>("SELECT top 1 * FROM [RoomPhoneRelation] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
            return relation;
        }
        public static Ui.DataGrid GetRoomPhoneRelationGridByRoomID(List<int> ProjectIDList, List<int> RoomIDList, string RelationType, string orderBy, long startRowIndex, int pageSize, bool IsContractUser, bool IsProjectUser)
        {
            long totalRows = 0;
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IsContractUser)
            {
                conditions.Add("[ContractID]>0");
            }
            else if (IsProjectUser)
            {
                conditions.Add("([ContractID]=0 or [ContractID] is null)");
            }
            else
            {
                dg.rows = new int[] { };
                dg.total = 0;
                dg.page = pageSize;
                return dg;
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [RoomID] =" + ProjectID + ")");
                }
                conditions.Add("exists(select 1 from [Project] where (" + string.Join(" or ", cmdlist.ToArray()) + ") and ([Project].ID=[RoomPhoneRelation].[RoomID] or exists(select 1 from [RoomPhoneRelation_Connect] where RoomPhoneRelation_Connect.[RoomPhoneRelationID]=[RoomPhoneRelation].ID and [Project].ID=RoomPhoneRelation_Connect.RoomID)))");
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("([RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ") or exists(select 1 from [RoomPhoneRelation_Connect] where RoomPhoneRelationID=RoomPhoneRelation.ID and [RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")))");
            }
            if (!string.IsNullOrEmpty(RelationType))
            {
                conditions.Add("([RelationType]=@RelationType or [RelationType] is null)");
                parameters.Add(new SqlParameter("@RelationType", RelationType));
            }
            string fieldList = "[RoomPhoneRelation].* ";
            string Statement = " from [RoomPhoneRelation] where  " + string.Join(" and ", conditions.ToArray());
            RoomPhoneRelationDetail[] list = new RoomPhoneRelationDetail[] { };
            list = GetList<RoomPhoneRelationDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            if (list.Length > 0)
            {
                int MinRoomID = list.Min(p => p.RoomID);
                int MaxRoomID = list.Max(p => p.RoomID);
                var projectList = Project.GetProjectListByMinMaxID(MinRoomID, MaxRoomID);
                int MinContracID = list.Min(p => p.ContractID);
                int MaxContractID = list.Max(p => p.ContractID);
                var contractList = Contract.GetContractListByMinMaxID(MinContracID, MaxContractID);
                foreach (var item in list)
                {
                    var myProject = projectList.FirstOrDefault(p => p.ID == item.RoomID);
                    if (myProject != null)
                    {
                        item.FullName = myProject.FullName;
                        item.RoomName = myProject.Name;
                    }
                    var myContract = contractList.FirstOrDefault(p => p.ID == item.ContractID);
                    if (myContract != null)
                    {
                        item.ContractName = myContract.ContractName;
                        item.ContractNo = myContract.ContractNo;
                    }
                }
            }
            dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static RoomPhoneRelation[] GetRoomPhoneRelationsByRoomIDList(List<int> RoomIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomIDList.Count == 0)
            {
                return new RoomPhoneRelation[] { };
            }
            conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            RoomPhoneRelation[] list = GetList<RoomPhoneRelation>("SELECT * FROM [RoomPhoneRelation] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static RoomPhoneRelation[] GetRoomPhoneRelationsByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return new RoomPhoneRelation[] { };
            }
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            RoomPhoneRelation[] list = GetList<RoomPhoneRelation>("SELECT * FROM [RoomPhoneRelation] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static RoomPhoneRelation[] GetRoomPhoneRelationsByPhone(string PhoneNumber, int uid = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                return new RoomPhoneRelation[] { };
            }
            if (uid > 0)
            {
                conditions.Add("[RelatePhoneNumber] in (select [LoginName] from [User] where [UserID]=@UserID or [ParentUserID]=@UserID)");
                parameters.Add(new SqlParameter("@UserID", uid));
            }
            conditions.Add("[RelatePhoneNumber]=@RelatePhoneNumber");
            parameters.Add(new SqlParameter("@RelatePhoneNumber", PhoneNumber));
            return GetList<RoomPhoneRelation>("select * from [RoomPhoneRelation] where " + string.Join(" or ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomPhoneRelation[] GetRoomPhoneRelationListByMinMaxRoomID(int MinRoomID, int MaxRoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("RoomID between " + MinRoomID + " and " + MaxRoomID);
            return GetList<RoomPhoneRelation>("select * from [RoomPhoneRelation] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomPhoneRelation[] GetRoomPhoneRelationListByMinMaxID(int MinID, int MaxID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ID between " + MinID + " and " + MaxID);
            return GetList<RoomPhoneRelation>("select * from [RoomPhoneRelation] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public string IsDefaultDesc
        {
            get
            {
                return this.IsDefault ? "是" : "否";
            }
        }
        public string IsChargeFeeDesc
        {
            get
            {
                return this.IsChargeFee ? "是" : "否";
            }
        }
        public string IsChargeManDesc
        {
            get
            {
                return this.IsChargeMan ? "是" : "否";
            }
        }
        public string RelationTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.RelationType))
                {
                    return string.Empty;
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
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(RelationPropertyDefine), this.RelationProperty);
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
        public string BirthdayDesc
        {
            get
            {
                if (this.Birthday == DateTime.MinValue)
                {
                    return string.Empty;
                }
                return this.Birthday.ToString("yyyy-MM-dd");
            }
        }
    }
    public partial class RoomPhoneRelationDetail : RoomPhoneRelation
    {
        public string FullName { get; set; }
        public string RoomName { get; set; }
        public string ContractName { get; set; }
        public string ContractNo { get; set; }
    }
    public enum RelationTypeDefine
    {
        [Description("业主")]
        homefamily,
        [Description("租户")]
        rentfamily,
    }
    public enum RelationPropertyDefine
    {
        [Description("个人")]
        geren,
        [Description("公司")]
        gongsi,
    }
}
