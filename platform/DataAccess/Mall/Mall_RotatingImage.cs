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
    /// This object represents the properties and methods of a Mall_RotatingImage.
    /// </summary>
    public partial class Mall_RotatingImage : EntityBase
    {
        public string IsActiveDesc
        {
            get
            {
                return this.IsActive ? "启用" : "停用";
            }
        }
        public static Mall_RotatingImage[] GetMall_RotatingImageListByType(int Type)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsActive]=1");
            conditions.Add("isnull([ImagePath],'')!=''");
            if (Type <= 0)
            {
                return new Mall_RotatingImage[] { };
            }
            conditions.Add("[Type]=@Type");
            parameters.Add(new SqlParameter("@Type", Type));
            return GetList<Mall_RotatingImage>("select * from [Mall_RotatingImage] where " + string.Join(" and ", conditions.ToArray()) + " order by [SortOrder] asc, [AddTime] desc", parameters).ToArray();
        }
        public static Ui.DataGrid GetMall_RotatingImageGridByType(int Type, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (Type > 0)
            {
                conditions.Add("Type=@Type");
                parameters.Add(new SqlParameter("@Type", Type));
            }
            string fieldList = "Mall_RotatingImage.*";
            string Statement = " from Mall_RotatingImage where  " + string.Join(" and ", conditions.ToArray());
            Mall_RotatingImage[] list = GetList<Mall_RotatingImage>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static List<Dictionary<string, object>> GetRotatingTypeList(bool IncludeALL = false)
        {
            var config = new Utility.SiteConfig();
            var list = new List<Dictionary<string, object>>();
            var dic = new Dictionary<string, object>();
            dic["id"] = 1;
            dic["name"] = "业主APP首页";
            list.Add(dic);
            dic = new Dictionary<string, object>();
            dic["id"] = 3;
            dic["name"] = "业主APP登录";
            list.Add(dic);
            dic = new Dictionary<string, object>();
            dic["id"] = 7;
            dic["name"] = "业主APP引导页";
            list.Add(dic);
            dic = new Dictionary<string, object>();
            dic["id"] = 9;
            dic["name"] = "业主APP引导页底部图片";
            list.Add(dic);
            if (config.IsFuShunJu)
            {
                dic = new Dictionary<string, object>();
                dic["id"] = 2;
                dic["name"] = "业主APP商城";
                list.Add(dic);
                dic = new Dictionary<string, object>();
                dic["id"] = 4;
                dic["name"] = "商家APP首页";
                list.Add(dic);
                dic = new Dictionary<string, object>();
                dic["id"] = 5;
                dic["name"] = "商家APP登录";
                list.Add(dic);
                dic = new Dictionary<string, object>();
                dic["id"] = 6;
                dic["name"] = "业主APP社区";
                list.Add(dic);
                dic = new Dictionary<string, object>();
                dic["id"] = 8;
                dic["name"] = "福顺券发放背景图片";
                list.Add(dic);
                dic = new Dictionary<string, object>();
                dic["id"] = 10;
                dic["name"] = "福顺券到期背景图片";
                list.Add(dic);
                dic = new Dictionary<string, object>();
                dic["id"] = 11;
                dic["name"] = "商圈模块福顺优选图片";
                list.Add(dic);
                dic = new Dictionary<string, object>();
                dic["id"] = 12;
                dic["name"] = "商圈模块团购图片";
                list.Add(dic);
                dic = new Dictionary<string, object>();
                dic["id"] = 13;
                dic["name"] = "商圈模块抢购图片";
                list.Add(dic);
                dic = new Dictionary<string, object>();
                dic["id"] = 14;
                dic["name"] = "新人专项资料完善图片";
                list.Add(dic);
                dic = new Dictionary<string, object>();
                dic["id"] = 15;
                dic["name"] = "员工APP首页";
                list.Add(dic);
            }
            if (IncludeALL)
            {
                dic = new Dictionary<string, object>();
                dic["id"] = 0;
                dic["name"] = "不限";
                list.Insert(0, dic);
            }
            return list;
        }
        public string TypeDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.Type)
                {
                    case 1:
                        desc = "业主APP首页";
                        break;
                    case 2:
                        desc = "业主APP商城";
                        break;
                    case 3:
                        desc = "业主APP登录";
                        break;
                    case 4:
                        desc = "商家APP首页";
                        break;
                    case 5:
                        desc = "商家APP登录";
                        break;
                    case 6:
                        desc = "业主APP社区";
                        break;
                    case 7:
                        desc = "业主APP引导页";
                        break;
                    case 8:
                        desc = "福顺券发放背景图片";
                        break;
                    case 9:
                        desc = "业主APP引导页底部图片";
                        break;
                    case 10:
                        desc = "福顺券到期背景图片";
                        break;
                    case 11:
                        desc = "商圈模块福顺优选图片";
                        break;
                    case 12:
                        desc = "商圈模块团购图片";
                        break;
                    case 13:
                        desc = "商圈模块抢购图片";
                        break;
                    case 14:
                        desc = "新人专项资料完善图片";
                        break;
                    case 15:
                        desc = "员工APP首页";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string URLLinkTypeDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.URLLinkType)
                {
                    case 1:
                        desc = "商品";
                        break;
                    case 2:
                        desc = "店铺";
                        break;
                    case 3:
                        desc = "物业公告";
                        break;
                    case 4:
                        desc = "小区新闻";
                        break;
                    case 5:
                        desc = "生活服务";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
    }
}
