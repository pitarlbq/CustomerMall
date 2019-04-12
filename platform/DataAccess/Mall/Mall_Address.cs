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
    /// This object represents the properties and methods of a Mall_Address.
    /// </summary>
    public partial class Mall_Address : EntityBase
    {
        public bool IsRelationAddress
        {
            get
            {
                return this.RoomID > 0;
            }
        }
        public static Mall_Address[] GetMall_AddressListByUserID(int FamilyUserID, int UserID = 0, bool DeleteRequired = true)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (FamilyUserID <= 0)
            {
                return new Mall_Address[] { };
            }
            if (UserID > 0)
            {
                conditions.Add("([UserID]=@FamilyUserID or [UserID]=@UserID)");
                parameters.Add(new SqlParameter("@FamilyUserID", FamilyUserID));
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            else
            {
                conditions.Add("[UserID]=@FamilyUserID");
                parameters.Add(new SqlParameter("@FamilyUserID", FamilyUserID));
            }
            if (DeleteRequired)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute("delete from [Mall_Address] where [RoomID]>0 and [RoomID] not in (select [ProjectID] from [Mall_UserProject] where isnull([IsDisable],0)=0 and " + string.Join(" and ", conditions.ToArray()) + ") and " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                    }
                }
            }
            return GetList<Mall_Address>("select * from [Mall_Address] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Mall_Address GetDefaultAddress(int FamilyUserID, int UserID = 0, string LoginName = "")
        {
            var list = Foresight.DataAccess.Mall_Address.GetMall_AddressListByUserID(FamilyUserID, UserID);
            var default_address = list.FirstOrDefault(p => p.IsDefault);
            var project_list = Foresight.DataAccess.Project.GetProjectListByAPPUserID(FamilyUserID);
            if (project_list.Length == 0)
            {
                return default_address;
            }
            var room_relation_list = Foresight.DataAccess.RoomPhoneRelation.GetRoomPhoneRelationsByRoomIDList(project_list.Select(p => p.ID).ToList());
            int item_index = 0;
            foreach (var item in project_list)
            {
                var my_room_relation = room_relation_list.FirstOrDefault(p => p.RoomID == item.ID && p.IsDefault);
                if (my_room_relation == null)
                {
                    my_room_relation = room_relation_list.FirstOrDefault(p => p.RoomID == item.ID);
                }
                if (my_room_relation == null)
                {
                    continue;
                }
                var address = list.FirstOrDefault(p => p.RoomID == item.ID);
                if (address != null)
                {
                    continue;
                }
                if (address == null)
                {
                    address = new Mall_Address();
                    address.AddTime = DateTime.Now;
                    address.AddUser = "System";
                }
                address.AddressProvice = item.AddressProvice;
                address.AddressCity = item.AddressCity;
                address.AddressDistrict = item.AddressDistrict;
                address.AddressDetailInfo = item.FullName + "-" + item.Name;
                if (my_room_relation != null)
                {
                    address.AddressPhoneNo = my_room_relation.RelatePhoneNumber;
                    address.AddressUserName = my_room_relation.RelationName;
                }
                if (string.IsNullOrEmpty(address.AddressPhoneNo))
                {
                    address.AddressPhoneNo = LoginName;
                }
                if (default_address == null)
                {
                    address.IsDefault = item_index == 0;
                }
                address.AddressProvinceID = item.AddressProvinceID;
                address.UserID = FamilyUserID;
                address.RoomPhoneRelationID = my_room_relation.ID;
                int ProjectID = 0;
                string[] AllParentIDArray = item.AllParentID.Split(',');
                foreach (var AllParentID in AllParentIDArray)
                {
                    if (string.IsNullOrEmpty(AllParentID))
                    {
                        continue;
                    }
                    int.TryParse(AllParentID, out ProjectID);
                    if (ProjectID > 1)
                    {
                        break;
                    }
                }
                address.ProjectID = ProjectID;
                address.RoomID = item.ID;
                address.ProjectFullName = item.FullName;
                address.RoomName = item.Name;
                string ProjectName = string.Empty;
                string[] FullNameArray = item.FullName.Split('-');
                foreach (var FullName in FullNameArray)
                {
                    if (string.IsNullOrEmpty(FullName))
                    {
                        continue;
                    }
                    ProjectName = FullName;
                    break;
                }
                address.ProjectName = ProjectName;
                address.Save();
                if (address.IsDefault)
                {
                    default_address = address;
                }
            }
            return default_address;
        }
        public string FinalAddressName
        {
            get
            {
                if (this.RoomID > 0)
                {
                    return this.AddressDetailInfo;
                }
                return this.AddressProvice + this.AddressCity + this.AddressDistrict + this.AddressDetailInfo;
            }
        }
    }
}
