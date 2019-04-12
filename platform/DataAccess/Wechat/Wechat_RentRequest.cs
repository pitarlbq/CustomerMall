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
	/// This object represents the properties and methods of a Wechat_RentRequest.
	/// </summary>
	public partial class Wechat_RentRequest : EntityBase
	{
        public string RentTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.RentType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatRentRequestRentTypeDefine), this.RentType);
            }
        }
        public string BuildingPropertyDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.BuildingProperty))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatRentRequestBuildingPropertyDefine), this.BuildingProperty);
            }
        }
	}
    public partial class Wechat_RentRequestDetail : Wechat_RentRequest
    {
        [DatabaseColumn("AreaName")]
        public string AreaName { get; set; }
        [DatabaseColumn("BuildingName")]
        public string BuildingName { get; set; }
        public static Ui.DataGrid GetWechat_RentRequestDetailGridByKeywords(string Keywords, List<int> AreaIDList, List<int> BuildingIDList, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add(" 1=1 ");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ContactName] like @Keywords or [ContactPhone] like @Keywords)");
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
            string Statement = " from (select *,(select AreaName from [Wechat_RentArea] where ID=Wechat_RentRequest.AreaID) as AreaName,(select BuildingName from [Wechat_RentBuilding] where ID=Wechat_RentRequest.BuildingID) as BuildingName from [Wechat_RentRequest])A where  " + string.Join(" and ", conditions.ToArray());
            Wechat_RentRequestDetail[] list = GetList<Wechat_RentRequestDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
