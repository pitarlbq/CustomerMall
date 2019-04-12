using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Utility
{
    public class SiteConfig
    {
        public SiteConfig()
        {
            SITE_URL = ConfigurationManager.AppSettings["SITE_URL"];
            SITE_URL = string.IsNullOrEmpty(SITE_URL) ? @"http://te-cool.com:99/" : SITE_URL;

            SitePath = ConfigurationManager.AppSettings["SitePath"];
            SitePath = string.IsNullOrEmpty(SitePath) ? @"E:\data\prosystem\SubSites\" : SitePath;

            ZipPath = ConfigurationManager.AppSettings["ZipPath"];
            ZipPath = string.IsNullOrEmpty(ZipPath) ? @"E:\data\prosystem\prosys\SQL\prosys.zip" : ZipPath;

            SiteNumber = ConfigurationManager.AppSettings["SiteNumber"];
            SiteNumber = string.IsNullOrEmpty(SiteNumber) ? "1" : SiteNumber;

            SiteName = ConfigurationManager.AppSettings["SiteName"];
            SiteName = string.IsNullOrEmpty(SiteName) ? "localhost" : SiteName;

            ConnString = ConfigurationManager.AppSettings["ConnString"];
            ConnString = string.IsNullOrEmpty(ConnString) ? @"data source=.;user id=sa;password=Axz$1985;persist security info=false;packet size=4096" : ConnString;

            DBFilePath = ConfigurationManager.AppSettings["DBFilePath"];
            DBFilePath = string.IsNullOrEmpty(DBFilePath) ? @"E:\SQL\Data\" : DBFilePath;

            sqlFileName = ConfigurationManager.AppSettings["sqlFileName"];
            sqlFileName = string.IsNullOrEmpty(sqlFileName) ? @"E:\data\prosystem\prosys\SQL\prostructure.sql" : sqlFileName;

            sqlFileData = ConfigurationManager.AppSettings["sqlFileData"];
            sqlFileData = string.IsNullOrEmpty(sqlFileData) ? @"E:\data\prosystem\prosys\SQL\prodata.sql" : sqlFileData;

            SysVersionCode = ConfigurationManager.AppSettings["SysVersionCode"];
            SysVersionCode = string.IsNullOrEmpty(SysVersionCode) ? "39" : SysVersionCode;

            SocketURL = ConfigurationManager.AppSettings["SocketURL"];
            SocketURL = string.IsNullOrEmpty(SocketURL) ? @"120.77.144.50:3000" : SocketURL;

            SocketLocalURL = ConfigurationManager.AppSettings["SocketLocalURL"];
            SocketLocalURL = string.IsNullOrEmpty(SocketLocalURL) ? @"172.18.174.157:3000" : SocketLocalURL;


            APIURL = ConfigurationManager.AppSettings["APIURL"];
            APIURL = string.IsNullOrEmpty(APIURL) ? @"http://120.77.144.50:10086/Handler/EncryptHandler.ashx" : APIURL;

            smsServer = ConfigurationManager.AppSettings["smsServer"];
            smsServer = string.IsNullOrEmpty(smsServer) ? @"http://120.76.25.160:7788/sms.aspx" : smsServer;

            smsUserID = ConfigurationManager.AppSettings["smsUserID"];
            smsUserID = string.IsNullOrEmpty(smsUserID) ? "793" : smsUserID;

            smsAccount = ConfigurationManager.AppSettings["smsAccount"];
            smsAccount = string.IsNullOrEmpty(smsAccount) ? "saasyy" : smsAccount;

            smsPassword = ConfigurationManager.AppSettings["smsPassword"];
            smsPassword = string.IsNullOrEmpty(smsPassword) ? "520620" : smsPassword;

            smsSign = ConfigurationManager.AppSettings["smsSign"];
            smsSign = string.IsNullOrEmpty(smsSign) ? "永友科技" : smsSign;

            wygltz = ConfigurationManager.AppSettings["物业管理通知"];
            wygltz = string.IsNullOrEmpty(wygltz) ? "/html/TemplateXml/wygltz.xml" : wygltz;

            wyzdcjtz = ConfigurationManager.AppSettings["物业账单催缴通知"];
            wyzdcjtz = string.IsNullOrEmpty(wyzdcjtz) ? "/html/TemplateXml/zdjftz.xml" : wyzdcjtz;

            kftztx = ConfigurationManager.AppSettings["客服通知提醒"];
            kftztx = string.IsNullOrEmpty(kftztx) ? "/html/TemplateXml/kftztx.xml" : kftztx;

            HuiShouYin_APPID = ConfigurationManager.AppSettings["HuiShouYin_APPID"];
            HuiShouYin_APPID = string.IsNullOrEmpty(HuiShouYin_APPID) ? "" : HuiShouYin_APPID;

            HuiShouYin_MCHUID = ConfigurationManager.AppSettings["HuiShouYin_MCHUID"];
            HuiShouYin_MCHUID = string.IsNullOrEmpty(HuiShouYin_MCHUID) ? "" : HuiShouYin_MCHUID;

            HuiShouYin_KEY = ConfigurationManager.AppSettings["HuiShouYin_KEY"];
            HuiShouYin_KEY = string.IsNullOrEmpty(HuiShouYin_KEY) ? "" : HuiShouYin_KEY;

            HuiShouYin_Enable = ConfigurationManager.AppSettings["HuiShouYin_Enable"];
            HuiShouYin_Enable = string.IsNullOrEmpty(HuiShouYin_Enable) ? "false" : HuiShouYin_Enable;

            EncriptURL = ConfigurationManager.AppSettings["EncriptURL"];
            EncriptURL = string.IsNullOrEmpty(EncriptURL) ? "0" : EncriptURL;

            IsLocalSite = ConfigurationManager.AppSettings["IsLocalSite"];
            IsLocalSite = string.IsNullOrEmpty(IsLocalSite) ? "false" : IsLocalSite;

            ServerSiteID = ConfigurationManager.AppSettings["ServerSiteID"];
            ServerSiteID = string.IsNullOrEmpty(ServerSiteID) ? "" : ServerSiteID;

            JPushKey_User = ConfigurationManager.AppSettings["JPushKey_User"];
            JPushKey_User = string.IsNullOrEmpty(JPushKey_User) ? "f25f2eb8c8cea16322be74d1" : JPushKey_User;

            JPushMasterSecret_User = ConfigurationManager.AppSettings["JPushMasterSecret_User"];
            JPushMasterSecret_User = string.IsNullOrEmpty(JPushMasterSecret_User) ? "a7f67b2c8878dac1a08fc594" : JPushMasterSecret_User;

            BaiduAK = ConfigurationManager.AppSettings["BaiduAK"];
            BaiduAK = string.IsNullOrEmpty(BaiduAK) ? "H0dLwwacQpSB7Qda53WL3wOS0gCLW1GE" : BaiduAK;

            Wechat_SiteNumber = ConfigurationManager.AppSettings["Wechat_SiteNumber"];
            Wechat_SiteNumber = string.IsNullOrEmpty(Wechat_SiteNumber) ? "3" : Wechat_SiteNumber;

            Wechat_SitePath = ConfigurationManager.AppSettings["Wechat_SitePath"];
            Wechat_SitePath = string.IsNullOrEmpty(Wechat_SitePath) ? @"E:\data\prosystem\prosys\data\" : Wechat_SitePath;

            Wechat_ZipPath = ConfigurationManager.AppSettings["Wechat_ZipPath"];
            Wechat_ZipPath = string.IsNullOrEmpty(Wechat_ZipPath) ? @"E:\data\prosystem\prosys\SQL\prosys_wx.zip" : Wechat_ZipPath;
            BackupFileLocation = ConfigurationManager.AppSettings["BackupFileLocation"];
            BackupFileLocation = string.IsNullOrEmpty(BackupFileLocation) ? @"E:\data\prosystem\prosys\data\" : BackupFileLocation;

            bool _PaasSmsServerEnable = false;
            string PaasSmsServerEnableStr = ConfigurationManager.AppSettings["PaasSmsServerEnable"];
            if (!string.IsNullOrEmpty(PaasSmsServerEnableStr))
            {
                bool.TryParse(PaasSmsServerEnableStr, out _PaasSmsServerEnable);
            }
            PaasSmsServerEnable = _PaasSmsServerEnable;

            PaasSmsServer = ConfigurationManager.AppSettings["PaasSmsServer"];
            PaasSmsServer = string.IsNullOrEmpty(PaasSmsServer) ? "http://sapi.253.com/msg/HttpBatchSendSM" : PaasSmsServer;

            PaasSms_UserName = ConfigurationManager.AppSettings["PaasSms_UserName"];
            PaasSms_UserName = string.IsNullOrEmpty(PaasSms_UserName) ? "daili2_FukHome" : PaasSms_UserName;

            PaasSms_Password = ConfigurationManager.AppSettings["PaasSms_Password"];
            PaasSms_Password = string.IsNullOrEmpty(PaasSms_Password) ? "GZfsju3333186" : PaasSms_Password;

            SQL_ZipPath = ConfigurationManager.AppSettings["SQL_ZipPath"];
            SQL_ZipPath = string.IsNullOrEmpty(SQL_ZipPath) ? @"E:\data\prosystem\prosys\SQL\prosys_wx.zip" : SQL_ZipPath;

            JPushKey_Customer = ConfigurationManager.AppSettings["JPushKey_Customer"];
            JPushKey_Customer = string.IsNullOrEmpty(JPushKey_Customer) ? "32f101fde82b8310063cc8ed" : JPushKey_Customer;

            JPushMasterSecret_Customer = ConfigurationManager.AppSettings["JPushMasterSecret_Customer"];
            JPushMasterSecret_Customer = string.IsNullOrEmpty(JPushMasterSecret_Customer) ? "6e836a4bf30caead5ead5a51" : JPushMasterSecret_Customer;

            bool DefaultIsMallOn = false;
            string IsMallOnStr = ConfigurationManager.AppSettings["IsMallOn"];
            if (!string.IsNullOrEmpty(IsMallOnStr))
            {
                bool.TryParse(IsMallOnStr, out DefaultIsMallOn);
            }
            IsMallOn = DefaultIsMallOn;

            LocalURL = ConfigurationManager.AppSettings["LocalURL"];
            LocalURL = string.IsNullOrEmpty(LocalURL) ? "http://172.18.174.157/" : LocalURL;

            DateTime _FirstOpenDoorExpireTime = DateTime.MinValue;
            string FirstOpenDoorExpireTimeStr = ConfigurationManager.AppSettings["FirstOpenDoorExpireTime"];
            if (!string.IsNullOrEmpty(FirstOpenDoorExpireTimeStr))
            {
                DateTime.TryParse(FirstOpenDoorExpireTimeStr, out _FirstOpenDoorExpireTime);
            }
            _FirstOpenDoorExpireTime = _FirstOpenDoorExpireTime == DateTime.MinValue ? Convert.ToDateTime("2018-08-01 00:00:00") : _FirstOpenDoorExpireTime;
            FirstOpenDoorExpireTime = _FirstOpenDoorExpireTime;

            SystemName = ConfigurationManager.AppSettings["SystemName"];
            SystemName = string.IsNullOrEmpty(SystemName) ? "永友网络科技" : SystemName;

            bool DefaultIsFuShunJu = false;
            string IsFuShunJuStr = ConfigurationManager.AppSettings["IsFuShunJu"];
            if (!string.IsNullOrEmpty(IsFuShunJuStr))
            {
                bool.TryParse(IsFuShunJuStr, out DefaultIsFuShunJu);
            }
            IsFuShunJu = DefaultIsFuShunJu;

            JPushKey_Business = ConfigurationManager.AppSettings["JPushKey_Business"];
            JPushKey_Business = string.IsNullOrEmpty(JPushKey_Business) ? "6e836a4bf30caead5ead5a51" : JPushKey_Business;

            JPushMasterSecret_Business = ConfigurationManager.AppSettings["JPushMasterSecret_Business"];
            JPushMasterSecret_Business = string.IsNullOrEmpty(JPushMasterSecret_Business) ? "6e836a4bf30caead5ead5a51" : JPushMasterSecret_Business;

            string CanAPPUserRegisterStr = ConfigurationManager.AppSettings["CanAPPUserRegister"];
            bool _CanAPPUserRegister = false;
            if (!string.IsNullOrEmpty(CanAPPUserRegisterStr))
            {
                bool.TryParse(CanAPPUserRegisterStr, out _CanAPPUserRegister);
            }
            CanAPPUserRegister = _CanAPPUserRegister;

            AlipayAPPID = ConfigurationManager.AppSettings["AlipayAPPID"];
            AlipayAPPID = string.IsNullOrEmpty(AlipayAPPID) ? string.Empty : AlipayAPPID;

            AlipaySellerID = ConfigurationManager.AppSettings["AlipaySellerID"];
            AlipaySellerID = string.IsNullOrEmpty(AlipaySellerID) ? string.Empty : AlipaySellerID;

            string IsWriteChequeOnStr = ConfigurationManager.AppSettings["IsWriteChequeOn"];
            bool _IsWriteChequeOn = false;
            if (!string.IsNullOrEmpty(IsWriteChequeOnStr))
            {
                bool.TryParse(IsWriteChequeOnStr, out _IsWriteChequeOn);
            }
            IsWriteChequeOn = _IsWriteChequeOn;

            Cheque_UserName = ConfigurationManager.AppSettings["Cheque_UserName"];
            Cheque_UserName = string.IsNullOrEmpty(Cheque_UserName) ? string.Empty : Cheque_UserName;

            Cheque_Password = ConfigurationManager.AppSettings["Cheque_Password"];
            Cheque_Password = string.IsNullOrEmpty(Cheque_Password) ? string.Empty : Cheque_Password;

            Cheque_QYSH = ConfigurationManager.AppSettings["Cheque_QYSH"];
            Cheque_QYSH = string.IsNullOrEmpty(Cheque_QYSH) ? string.Empty : Cheque_QYSH;

            Cheque_APPID = ConfigurationManager.AppSettings["Cheque_APPID"];
            Cheque_APPID = string.IsNullOrEmpty(Cheque_APPID) ? string.Empty : Cheque_APPID;

            Cheque_FLBM = ConfigurationManager.AppSettings["Cheque_FLBM"];
            Cheque_FLBM = string.IsNullOrEmpty(Cheque_FLBM) ? string.Empty : Cheque_FLBM;

            bool DefaultIsMallBusinessOn = false;
            string IsMallBusinessOnStr = ConfigurationManager.AppSettings["IsMallBusinessOn"];
            if (!string.IsNullOrEmpty(IsMallBusinessOnStr))
            {
                bool.TryParse(IsMallBusinessOnStr, out DefaultIsMallBusinessOn);
            }
            IsMallBusinessOn = DefaultIsMallBusinessOn;

            bool DefaultIsMallInHouseUserOn = false;
            string IsMallInHouseUserOnStr = ConfigurationManager.AppSettings["IsMallInHouseUserOn"];
            if (!string.IsNullOrEmpty(IsMallInHouseUserOnStr))
            {
                bool.TryParse(IsMallInHouseUserOnStr, out DefaultIsMallInHouseUserOn);
            }
            IsMallInHouseUserOn = DefaultIsMallInHouseUserOn;

            ChatServiceStartTime = ConfigurationManager.AppSettings["chatServiceStartTime"];
            ChatServiceStartTime = string.IsNullOrEmpty(ChatServiceStartTime) ? "00:00" : ChatServiceStartTime;

            ChatServiceEndTime = ConfigurationManager.AppSettings["chatServiceEndTime"];
            ChatServiceEndTime = string.IsNullOrEmpty(ChatServiceEndTime) ? "00:00" : ChatServiceEndTime;

            ChatServiceNotWorkMsg = ConfigurationManager.AppSettings["chatServiceNotWorkMsg"];
            ChatServiceNotWorkMsg = string.IsNullOrEmpty(ChatServiceNotWorkMsg) ? string.Empty : ChatServiceNotWorkMsg;

            ChatServiceWorkMsg = ConfigurationManager.AppSettings["chatServiceWorkMsg"];
            ChatServiceWorkMsg = string.IsNullOrEmpty(ChatServiceWorkMsg) ? string.Empty : ChatServiceWorkMsg;

            bool DefaultIsAppUserLoginOn = true;
            string IsAppUserLoginOnStr = ConfigurationManager.AppSettings["IsAppUserLoginOn"];
            if (!string.IsNullOrEmpty(IsAppUserLoginOnStr))
            {
                bool.TryParse(IsAppUserLoginOnStr, out DefaultIsAppUserLoginOn);
            }
            IsAppUserLoginOn = DefaultIsAppUserLoginOn;

            int DefaultTotalRoomCount = 5000;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["TotalRoomCount"]))
            {
                int.TryParse(ConfigurationManager.AppSettings["TotalRoomCount"], out DefaultTotalRoomCount);
            }
            TotalRoomCount = DefaultTotalRoomCount;

            bool defaultCheckOwnerInStatus = false;
            string CheckOwnerInStatusStr = ConfigurationManager.AppSettings["CheckOwnerInStatus"];
            if (!string.IsNullOrEmpty(CheckOwnerInStatusStr))
            {
                bool.TryParse(CheckOwnerInStatusStr, out defaultCheckOwnerInStatus);
            }
            CheckOwnerInStatus = defaultCheckOwnerInStatus;

            PreIndex = ConfigurationManager.AppSettings["PreIndex"];
            if (string.IsNullOrEmpty(PreIndex))
            {
                PreIndex = Utility.Tools.getApplicationPath();
                if (PreIndex.Length > 0)
                {
                    PreIndex = PreIndex.Substring(1, PreIndex.Length - 1);
                }
            }
            PreIndex = string.IsNullOrEmpty(PreIndex) ? "saasyy" : PreIndex;

            bool _tencentSmsEnable = false;
            string tencentSmsEnableStr = ConfigurationManager.AppSettings["tencentSmsEnable"];
            if (!string.IsNullOrEmpty(tencentSmsEnableStr))
            {
                bool.TryParse(tencentSmsEnableStr, out _tencentSmsEnable);
            }
            tencentSmsEnable = _tencentSmsEnable;

            tencentAppID = ConfigurationManager.AppSettings["tencentAppID"];
            tencentAppID = string.IsNullOrEmpty(tencentAppID) ? "1400176446" : tencentAppID;

            tencentAppKey = ConfigurationManager.AppSettings["tencentAppKey"];
            tencentAppKey = string.IsNullOrEmpty(tencentAppKey) ? "cc515c02ace142198eb884e8e73aa6d1" : tencentAppKey;

            tencentServer = ConfigurationManager.AppSettings["tencentServer"];
            tencentServer = string.IsNullOrEmpty(tencentServer) ? "https://yun.tim.qq.com/v5/tlssmssvr/sendsms?sdkappid={0}&random={1}" : tencentServer;

            int _tencentTemplateID = 261875;
            string tencentTemplateIDStr = ConfigurationManager.AppSettings["tencentTemplateID"];
            if (!string.IsNullOrEmpty(tencentTemplateIDStr))
            {
                int.TryParse(tencentTemplateIDStr, out _tencentTemplateID);
            }
            tencentTemplateID = _tencentTemplateID;

            bool _IsAdminSite = false;
            string IsAdminSiteStr = ConfigurationManager.AppSettings["IsAdminSite"];
            if (!string.IsNullOrEmpty(IsAdminSiteStr))
            {
                bool.TryParse(IsAdminSiteStr, out _IsAdminSite);
            }
            IsAdminSite = _IsAdminSite;

            bool _IsDemoSite = false;
            string IsDemoSiteStr = ConfigurationManager.AppSettings["IsDemoSite"];
            if (!string.IsNullOrEmpty(IsDemoSiteStr))
            {
                bool.TryParse(IsDemoSiteStr, out _IsDemoSite);
            }
            IsDemoSite = _IsDemoSite;

            bool _IsNewContract = false;
            string IsNewContractStr = ConfigurationManager.AppSettings["IsNewContract"];
            if (!string.IsNullOrEmpty(IsNewContractStr))
            {
                bool.TryParse(IsNewContractStr, out _IsNewContract);
            }
            IsNewContract = _IsNewContract;
        }
        /// <summary>
        /// 数据库备份统一地址
        /// </summary>
        public string BackupFileLocation { get; set; }
        /// <summary>
        /// 发布系统一级URL
        /// </summary>
        public string SITE_URL { get; set; }
        /// <summary>
        /// 发布系统文件路径
        /// </summary>
        public string SitePath { get; set; }
        /// <summary>
        /// 系统文件压缩包
        /// </summary>
        public string ZipPath { get; set; }
        /// <summary>
        /// 根系统网站ID
        /// </summary>
        public string SiteNumber { get; set; }
        /// <summary>
        /// 服务器站点名称
        /// </summary>
        public string SiteName { get; set; }
        /// <summary>
        /// 数据库连接池
        /// </summary>
        public string ConnString { get; set; }
        /// <summary>
        /// 系统数据库存放路径
        /// </summary>
        public string DBFilePath { get; set; }
        /// <summary>
        /// 数据库结构脚本
        /// </summary>
        public string sqlFileName { get; set; }
        /// <summary>
        /// 数据库数据脚本
        /// </summary>
        public string sqlFileData { get; set; }
        /// <summary>
        /// socket地址
        /// </summary>
        public string SocketURL { get; set; }
        /// <summary>
        /// socket地址
        /// </summary>
        public string SocketLocalURL { get; set; }
        /// <summary>
        /// 应用程序访问admin系统地址
        /// </summary>
        public string APIURL { get; set; }
        /// <summary>
        /// 当前更新系统号
        /// </summary>
        public string SysVersionCode { get; set; }
        /// <summary>
        /// 短信服务器地址
        /// </summary>
        public string smsServer { get; set; }
        /// <summary>
        /// 短信用户ID
        /// </summary>
        public string smsUserID { get; set; }
        /// <summary>
        /// 短信服务帐号
        /// </summary>
        public string smsAccount { get; set; }
        /// <summary>
        /// 短息密码
        /// </summary>
        public string smsPassword { get; set; }
        /// <summary>
        /// 短信签名
        /// </summary>
        public string smsSign { get; set; }
        /// <summary>
        /// 物业管理通知
        /// </summary>
        public string wygltz { get; set; }
        /// <summary>
        /// 物业账单催缴通知
        /// </summary>
        public string wyzdcjtz { get; set; }
        /// <summary>
        /// 客服通知提醒
        /// </summary>
        public string kftztx { get; set; }
        /// <summary>
        /// 汇收银APPID
        /// </summary>
        public string HuiShouYin_APPID { get; set; }
        /// <summary>
        /// 汇收银MCHUID
        /// </summary>
        public string HuiShouYin_MCHUID { get; set; }
        /// <summary>
        /// 汇收银KEY
        /// </summary>
        public string HuiShouYin_KEY { get; set; }
        /// <summary>
        /// 启动汇收银
        /// </summary>
        public string HuiShouYin_Enable { get; set; }
        /// <summary>
        /// URL加密
        /// </summary>
        public string EncriptURL { get; set; }
        /// <summary>
        /// 是否单机系统
        /// </summary>
        public string IsLocalSite { get; set; }
        /// <summary>
        /// 在admin系统公司ID（仅限单机系统使用）
        /// </summary>
        public string ServerSiteID { get; set; }
        /// <summary>
        /// 员工端APP极光推送Key
        /// </summary>
        public string JPushKey_User { get; set; }
        /// <summary>
        /// 员工端APP极光推送密钥
        /// </summary>
        public string JPushMasterSecret_User { get; set; }
        /// <summary>
        /// 百度地图Key
        /// </summary>
        public string BaiduAK { get; set; }
        /// <summary>
        /// 根微信网站ID
        /// </summary>
        public string Wechat_SiteNumber { get; set; }
        /// <summary>
        /// 根微信网站文件路径
        /// </summary>
        public string Wechat_ZipPath { get; set; }
        /// <summary>
        /// 根微信网站根路径
        /// </summary>
        public string Wechat_SitePath { get; set; }
        public bool PaasSmsServerEnable { get; set; }

        /// <summary>
        /// Paas短信服务器地址
        /// </summary>
        public string PaasSmsServer { get; set; }
        /// <summary>
        /// Paas短信服务帐号
        /// </summary>
        public string PaasSms_UserName { get; set; }
        /// <summary>
        /// Paas短息密码
        /// </summary>
        public string PaasSms_Password { get; set; }

        public string SQL_ZipPath { get; set; }
        /// <summary>
        /// 业主端APP极光推送Key
        /// </summary>
        public string JPushKey_Customer { get; set; }
        /// <summary>
        /// 业主端APP极光推送密钥
        /// </summary>
        public string JPushMasterSecret_Customer { get; set; }

        public bool IsMallOn { get; set; }

        public string LocalURL { get; set; }

        public DateTime FirstOpenDoorExpireTime { get; set; }

        public string SystemName { get; set; }

        public bool IsFuShunJu { get; set; }

        public string JPushKey_Business { get; set; }

        public string JPushMasterSecret_Business { get; set; }
        public bool CanAPPUserRegister { get; set; }
        public string AlipayAPPID { get; set; }
        public string AlipaySellerID { get; set; }
        public bool IsWriteChequeOn { get; set; }
        public string Cheque_UserName { get; set; }
        public string Cheque_Password { get; set; }
        public string Cheque_QYSH { get; set; }
        public string Cheque_APPID { get; set; }
        public string Cheque_FLBM { get; set; }
        public bool IsMallBusinessOn { get; set; }
        public bool IsMallInHouseUserOn { get; set; }
        public string ChatServiceStartTime { get; set; }
        public string ChatServiceEndTime { get; set; }
        public string ChatServiceNotWorkMsg { get; set; }
        public string ChatServiceWorkMsg { get; set; }
        public bool IsAppUserLoginOn { get; set; }
        public int TotalRoomCount { get; set; }
        public bool CheckOwnerInStatus { get; set; }
        public string PreIndex { get; set; }
        public string WechatAutoResponseMsg
        {
            get
            {
                string msg = "客服正忙...";
                this.ChatServiceNotWorkMsg = string.IsNullOrEmpty(this.ChatServiceNotWorkMsg) ? msg : this.ChatServiceNotWorkMsg;
                this.ChatServiceWorkMsg = string.IsNullOrEmpty(this.ChatServiceWorkMsg) ? msg : this.ChatServiceWorkMsg;
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(DateTime.Today.ToString("yyyy-MM-dd") + " " + this.ChatServiceStartTime, out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(DateTime.Today.ToString("yyyy-MM-dd") + " " + this.ChatServiceEndTime, out EndTime);
                if (StartTime > DateTime.Now)
                {
                    return this.ChatServiceNotWorkMsg;
                }
                if (EndTime < DateTime.Now)
                {
                    return this.ChatServiceNotWorkMsg;
                }
                return this.ChatServiceWorkMsg;
            }
        }
        public bool tencentSmsEnable { get; set; }
        public string tencentServer { get; set; }
        public int tencentTemplateID { get; set; }
        public string tencentAppID { get; set; }
        public string tencentAppKey { get; set; }
        public bool IsAdminSite { get; set; }
        public bool IsDemoSite { get; set; }
        public bool IsNewContract { get; set; }
        public bool SmsServerEnable
        {
            get
            {
                return this.PaasSmsServerEnable || this.tencentSmsEnable;
            }
        }
    }
}
