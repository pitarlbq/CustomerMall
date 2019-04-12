using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YongYou.Server
{
    public class BaseResponse
    {
        public bool status { get; set; }
    }
    public class URLList : BaseResponse
    {
        public List<Utility.ServerCompanyModel> urls { get; set; }
    }
    public class BackupResponse : BaseResponse
    {
        public int sentcound { get; set; }
        public List<string> companynamelist { get; set; }
    }
    public class ALLTaskResponse : BaseResponse
    {
        public string companyname { get; set; }
        public int repaircount { get; set; }
        public int checkcount { get; set; }
        public int sendtempltemsgcount { get; set; }
        public int senddevicetaskcount { get; set; }
        public int sendnotifyfeecount { get; set; }
        public int sendtuantaskcount { get; set; }
        public int sendxianshitaskcount { get; set; }
        public int sendbirthdaycount { get; set; }
        public int closemallordercount { get; set; }
        public int completemallordercount { get; set; }
        public int ratemallordercount { get; set; }
        public int fixedpointcount { get; set; }
        public int jixiaopointactivecount { get; set; }
        public int sendactiveuserbalancecount { get; set; }
        public int sendactiveuserpointcount { get; set; }
        public int sendactiveusercouponcount { get; set; }
    }
}
