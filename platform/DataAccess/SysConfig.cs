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
    /// This object represents the properties and methods of a SysConfig.
    /// </summary>
    public partial class SysConfig : EntityBase
    {
        public int ProjectID { get; set; }
        public static SysConfig GetSysConfigByName(string Name, SqlHelper helper = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (string.IsNullOrEmpty(Name))
            {
                return null;
            }
            conditions.Add("[Name]=@Name");
            parameters.Add(new SqlParameter("@Name", Name));
            string cmdtext = "select * from [SysConfig] where " + string.Join(" and ", conditions.ToArray());
            if (helper == null)
            {
                return GetOne<SysConfig>(cmdtext, parameters);
            }
            return GetOne<SysConfig>(cmdtext, parameters, helper);
        }
        public static string GetSignature(SqlHelper helper = null)
        {
            var Name = SysConfigNameDefine.auth_signature.ToString();
            var data = GetSysConfigByName(Name, helper: helper);
            if (data == null)
            {
                data = new SysConfig();
                data.Value = Utility.Tools.GetRandomString(32, true, false, true);
                data.Name = Name;
                data.AddTime = DateTime.Now;
                if (helper == null)
                {
                    data.Save();
                }
                else
                {
                    data.Save(helper);
                }
            }
            return data.Value;
        }
        public static string GetToken(SqlHelper helper = null)
        {
            var Name = SysConfigNameDefine.auth_token.ToString();
            var data = GetSysConfigByName(Name, helper: helper);
            if (data == null)
            {
                data = new SysConfig();
                data.Value = Utility.Tools.GetByteString(4);
                data.Name = Name;
                data.AddTime = DateTime.Now;
                if (helper == null)
                {
                    data.Save();
                }
                else
                {
                    data.Save(helper);
                }
            }
            return data.Value;
        }
        public static SysConfig[] GetSysConfigListByName(string Name)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string Name1 = SysConfigNameDefine.WechatFeeNotify.ToString();
            string Name2 = SysConfigNameDefine.WechatFeeNotifyTime.ToString();
            var conditions = new List<string>();
            if (Name.Equals(Name))
            {
                conditions.Add("[Name]=@Name1 or [Name]=@Name2");
                parameters.Add(new SqlParameter("@Name1", Name1));
                parameters.Add(new SqlParameter("@Name2", Name2));
            }
            else
            {
                conditions.Add("[Name]=@Name");
                parameters.Add(new SqlParameter("@Name", Name));
            }
            return GetList<SysConfig>("select * from [SysConfig] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static SysConfig[] GetSysConfigListByType(string ConfigType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ConfigType", ConfigType));
            return GetList<SysConfig>("select * from [SysConfig] where [ConfigType]=@ConfigType", parameters).ToArray();
        }
        public static SysConfig SaveSysConfigByType(SysConfig[] list, string Name, string Value, string ConfigType = "Wechat", bool CanSaveValue = true)
        {
            var data = list.FirstOrDefault(p => p.Name.Equals(Name));
            if (data == null)
            {
                data = new SysConfig();
                data.AddTime = DateTime.Now;
                data.ConfigType = ConfigType;
                data.Name = Name;
                data.Value = Value;
            }
            if (CanSaveValue)
            {
                data.Value = Value;
            }
            data.Save();
            return data;
        }
        public static SysConfig[] Get_SysConfigList(int ProjectID = 0)
        {
            return Get_SysConfigListByProjectIDList(MinProjectID: ProjectID, MaxProjectID: ProjectID);
        }
        public static SysConfig[] Get_SysConfigListByProjectIDList(int MinProjectID = 0, int MaxProjectID = 0, SysConfigNameDefine? ConfigName = null)
        {
            SysConfig[] list = new SysConfig[] { };
            if (ConfigName == null)
            {
                list = SysConfig.GetSysConfigs().ToArray();
            }
            else if (ConfigName == SysConfigNameDefine.WechatFeeNotify)
            {
                list = SysConfig.GetSysConfigs().Where(p => p.Name.Equals(SysConfigNameDefine.WechatFeeNotify.ToString()) || p.Name.Equals(SysConfigNameDefine.WechatFeeNotifyTime.ToString())).ToArray();
            }
            else
            {
                list = SysConfig.GetSysConfigs().Where(p => p.Name.Equals(ConfigName.ToString())).ToArray();
            }
            if (MaxProjectID > 0)
            {
                var config_project_list = SysConfig_ProjectDetail.Get_SysConfig_ProjectListByProjectIDList(MinProjectID, MaxProjectID);
                foreach (var item in list)
                {
                    var my_config = config_project_list.Where(p => p.ConfigID == item.ID).OrderByDescending(p => p.IconID).FirstOrDefault();
                    if (my_config != null)
                    {
                        item.Value = my_config.ConfigValue;
                        item.ProjectID = my_config.ProjectID;
                    }
                }
            }
            return list;
        }
        public static string GetSysConfigValueByName(SysConfig[] list, SysConfigNameDefine Name)
        {
            var data = list.FirstOrDefault(p => p.Name.Equals(Name.ToString()));
            return data == null ? string.Empty : data.Value;
        }
        public static void SaveSysConfigValueByName(SysConfig[] list, SysConfigNameDefine Name, string Value, SysConfig_Project[] configProjectList = null, int ProjectID = 0)
        {
            var data = list.FirstOrDefault(p => p.Name.Equals(Name.ToString()));
            if (data == null)
            {
                data = new SysConfig();
                data.Name = Name.ToString();
                data.AddTime = DateTime.Now;
            }
            if (ProjectID <= 1)
            {
                data.Value = Value;
            }
            data.Save();
            if (ProjectID > 1 && configProjectList != null)
            {
                var configProject = configProjectList.FirstOrDefault(p => p.ConfigID == data.ID && p.ProjectID == ProjectID);
                if (configProject == null)
                {
                    configProject = new SysConfig_Project();
                    configProject.AddTime = DateTime.Now;
                    configProject.ProjectID = ProjectID;
                    configProject.ConfigID = data.ID;
                }
                configProject.ConfigValue = Value;
                configProject.Save();
            }
        }
        public static bool IsCouZhengOn(SysConfig[] configList, string AllParentID = "")
        {
            string value = GetConfigValueByList(configList, SysConfigNameDefine.RealCostCouZhengOn, AllParentID: AllParentID);
            if (string.IsNullOrEmpty(value) || value.Equals("0"))
            {
                return false;
            }
            return true;
        }
        public static string GetConfigValueByList(SysConfig[] configList, SysConfigNameDefine ConfigName, string AllParentID = "")
        {
            SysConfig[] myConfigList = new SysConfig[] { };
            if (!string.IsNullOrEmpty(AllParentID))
            {
                myConfigList = configList.Where(p => AllParentID.Contains("," + p.ProjectID + ",") || p.ProjectID <= 1).ToArray();
            }
            if (myConfigList.Length == 0)
            {
                myConfigList = configList;
            }
            var config = myConfigList.FirstOrDefault(p => p.Name.Equals(ConfigName.ToString()));
            if (config == null)
            {
                return string.Empty;
            }
            return config.Value;
        }
        public static string GetSysConfigValueByAllParentID(SysConfig_ProjectDetail[] configProjectList, string AllParentID, int RoomID, SysConfig sysConfig)
        {
            var myConfig = SysConfig_ProjectDetail.GetSysConfig_ProjectDetailByAllParentID(configProjectList, AllParentID, RoomID);
            if (myConfig != null)
            {
                return myConfig.ConfigValue;
            }
            if (sysConfig != null)
            {
                return sysConfig.Value;
            }
            return string.Empty;
        }
        public static bool IsCouZhengOnByAllParentID(SysConfig_ProjectDetail[] configProjectList, string AllParentID, int RoomID, SysConfig sysConfig)
        {
            string ConfigValue = GetSysConfigValueByAllParentID(configProjectList, AllParentID, RoomID, sysConfig);
            if (string.IsNullOrEmpty(ConfigValue) || ConfigValue.Equals("0"))
            {
                return false;
            }
            return true;
        }
        public static bool IsShowCustomerCuiShouByAllParentID(SysConfig_ProjectDetail[] configProjectList, string AllParentID, int RoomID, SysConfig sysConfig)
        {
            string ConfigValue = GetSysConfigValueByAllParentID(configProjectList, AllParentID, RoomID, sysConfig);
            if (string.IsNullOrEmpty(ConfigValue) || ConfigValue.Equals("0"))
            {
                return true;
            }
            return false;
        }
    }
    public enum SysConfigNameDefine
    {
        [Description("是否启用尾数凑整")]
        RealCostCouZhengOn,
        [Description("合同提前预警")]
        ContractWarning,
        [Description("微信默认收款人")]
        WeixinChargeMan,
        [Description("催收通知单客户名称隐藏")]
        HideCuiShouCustomerName,
        [Description("微信缴费通知天数")]
        WechatFeeNotify,
        [Description("微信缴费通知日期")]
        WechatFeeNotifyTime,
        [Description("待付款订单自动关闭")]
        OrderCloseTime,
        [Description("已发货订单自动收货")]
        OrderAuoShipped,
        [Description("已收获订单自动评价")]
        OrderAutoRate,
        [Description("已付款订单退款时间")]
        OrderRefundTime,
        [Description("允许用户使用自定义地址")]
        AllowDefineAddress,
        [Description("短信用户名")]
        SMSUserName,
        [Description("短信密码")]
        SMSPassword,
        [Description("商家距离")]
        BusinessDistance,
        [Description("限时购提前推送时间设置")]
        JPushXianShiNotify,
        [Description("团购提前推送时间设置")]
        JPushTuanGouNotify,
        [Description("用户生日提前推送优惠券天数")]
        UserBirthdayBefore,
        [Description("用户生日提前推送优惠券")]
        UserBirthdayCoupon,
        [Description("每行分类个数")]
        MallCategoryLineCount,
        [Description("每月几号发送岗位积分")]
        SendJiXiaoPointDay,
        [Description("每月几号固定积分生效")]
        FixedPointActiveDay,
        [Description("第一次修改用户生日提示信息")]
        FirstChangeBirthdayNote,
        [Description("APP首页福顺优选显示商品数量")]
        MallHomeYouXuanCount,
        [Description("APP首页拼团秒杀显示商品数量")]
        MallHomePinTanCount,
        [Description("APP首页推荐商家显示商品数量")]
        MallHomeBusinessCount,
        [Description("APP首页热门消费显示商品数量")]
        MallHomeHotSaleCount,
        [Description("APP商圈分类显示数量")]
        MallMallCategoryCount,
        [Description("APP商圈优选商家显示数量")]
        MallMallBusinessCount,
        [Description("签名")]
        auth_signature,
        [Description("令牌")]
        auth_token,
        [Description("无人抢单自动派单时间")]
        NoGrabTransfer,
        [Description("门禁延期天数")]
        DoorDelayDay,
        [Description("物业欠费门禁到期提醒提前天数")]
        NotifyOpenDoorBeforeFeeDay,
        [Description("开门成功提示音")]
        OpenDoorVideoFilePath,
        [Description("客服服务工作开始时间")]
        WechatChatStartTime,
        [Description("客服服务工作结束时间")]
        WechatChatEndTime,
        [Description("客服离线留言")]
        WechatChatLeaveMsg,
        [Description("非工作时间留言")]
        WechatChatNotWorkMsg,
        [Description("访客二维码最大有效分钟")]
        QrCodeMaxEndTime,
        [Description("访客二维码最大开门次数")]
        QrCodeMaxOpenCount,
        [Description("微信房间关联图片")]
        WechatConnnectRoomSummary
    }
}
