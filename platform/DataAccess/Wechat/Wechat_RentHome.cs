using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Wechat_RentHome.
    /// </summary>
    public partial class Wechat_RentHome : EntityBase
    {
        public string HomeTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.HomeType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatRentHomeTypeDefine), this.HomeType);
            }
        }
    }
    public partial class Wechat_RentHomeDetail : Wechat_RentHome
    {
        [DatabaseColumn("AreaName")]
        public string AreaName { get; set; }
        [DatabaseColumn("BuildingName")]
        public string BuildingName { get; set; }
        public static Ui.DataGrid GeWechat_RentHomeDetailGridByKeywords(string Keywords, List<int> AreaIDList, List<int> BuildingIDList, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add(" 1=1 ");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([AreaName] like @Keywords or [HomeName] like @Keywords or [HomeLocation] like @Keywords or [PhoneNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (AreaIDList.Count > 0)
            {
                conditions.Add("[AreaID] in (" + string.Join(",", AreaIDList.ToArray()) + ")");
            }
            if (BuildingIDList.Count > 0)
            {
                conditions.Add("[BuildingID] in (" + string.Join(",", BuildingIDList.ToArray()) + ")");
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(select AreaName from [Wechat_RentArea] where ID=Wechat_RentHome.AreaID) as AreaName,(select BuildingName from [Wechat_RentBuilding] where ID=Wechat_RentHome.BuildingID) as BuildingName from [Wechat_RentHome])A where  " + string.Join(" and ", conditions.ToArray());
            Wechat_RentHomeDetail[] list = GetList<Wechat_RentHomeDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Wechat_RentHomeDetail[] GetWechat_RentHomeDetailListByKeywords(string keywords, List<string> arealist, List<string> pricelist, List<string> subwaylist, List<string> roomtypelist, long startRowIndex, int pageSize, out long totalRows)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string orderby = " order by [AddTime] desc";
            conditions.Add("[ID] in (select [RentRoomID] from [Wechat_RentHomeType] where [RentStatus]=0 and [UnitPrice]>0)");
            if (arealist.Count > 0)
            {
                conditions.Add("[AreaID] in (" + string.Join(",", arealist.ToArray()) + ")");
            }
            if (pricelist.Count > 0)
            {
                List<string> sub_conditions = new List<string>();
                foreach (var item in pricelist)
                {
                    if (!item.Contains("-"))
                    {
                        continue;
                    }
                    decimal price_min = 0;
                    decimal.TryParse(item.Split('-')[0], out price_min);
                    decimal price_max = 0;
                    decimal.TryParse(item.Split('-')[1], out price_max);
                    if (price_min <= 0 && price_max <= 0)
                    {
                        continue;
                    }
                    if (price_max <= 0)
                    {
                        sub_conditions.Add("([UnitPrice]>=" + price_min + ")");
                    }
                    else
                    {
                        sub_conditions.Add("([UnitPrice]>=" + price_min + " and [UnitPrice]<=" + price_max + ")");
                    }
                }
                if (sub_conditions.Count > 0)
                {
                    conditions.Add("[ID] in (select [RentRoomID] from [Wechat_RentHomeType] where [RentStatus]=0 and " + string.Join(" or ", sub_conditions.ToArray()) + ")");
                }
            }
            if (subwaylist.Count > 0)
            {
                List<string> sub_conditions = new List<string>();
                foreach (var item in subwaylist)
                {
                    sub_conditions.Add("([Subways] like '%" + item + "%')");
                }
                conditions.Add("(" + string.Join(" or ", sub_conditions.ToArray()) + ")");
            }
            if (roomtypelist.Count > 0)
            {
                List<string> sub_conditions = new List<string>();
                foreach (var item in roomtypelist)
                {
                    sub_conditions.Add("([HomeType]='" + item + "')");
                }
                conditions.Add("(" + string.Join(" or ", sub_conditions.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([HomeName] like @keywords or [HomeLocation] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "[Wechat_RentHome].*";
            string Statement = " from [Wechat_RentHome] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Wechat_RentHomeDetail>(fieldList, Statement, parameters, orderby, startRowIndex, pageSize, out totalRows).ToArray();
            return list;
        }
        public static Wechat_RentHomeDetail[] GetWechat_RentHomeDetailListByAreaIDList(List<int> AreaIDList, List<int> BuildingIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            List<string> sub_conditions = new List<string>();
            if (BuildingIDList.Count > 0)
            {
                sub_conditions.Add("[BuildingID] in (" + string.Join(",", BuildingIDList.ToArray()) + ")");
            }
            if (AreaIDList.Count > 0)
            {
                sub_conditions.Add("[AreaID] in (" + string.Join(",", AreaIDList.ToArray()) + ")");
            }
            if (sub_conditions.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", sub_conditions.ToArray()) + ")");
            }
            return GetList<Wechat_RentHomeDetail>("select *,(select AreaName from [Wechat_RentArea] where ID=Wechat_RentHome.AreaID) as AreaName from [Wechat_RentHome] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters).ToArray();
        }
    }
}
