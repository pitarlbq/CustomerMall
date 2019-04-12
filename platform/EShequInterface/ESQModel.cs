using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShequInterface
{
    public class ESQCommResponse
    {
        public string result { get; set; }
    }
    public class AuthSDOResponse : ESQCommResponse
    {
        public string data { get; set; }
    }

    public class SectResponse : ESQCommResponse
    {
        public Sect_InfoModel data { get; set; }
    }
    public class Sect_InfoModel
    {
        public SectModel[] sect_info { get; set; }
    }
    public class SectModel
    {
        public string sect_id { get; set; }
        public string sect_name { get; set; }
        public string sect_addr { get; set; }
    }

    public class BuildResponse : ESQCommResponse
    {
        public Build_InfoModel data { get; set; }
    }
    public class Build_InfoModel
    {
        public BuildModel[] build_info { get; set; }
    }
    public class BuildModel
    {
        public string build_id { get; set; }
        public string buiid_no { get; set; }
        public string build_addr { get; set; }
        public string sect_id { get; set; }
    }

    public class UnitResponse : ESQCommResponse
    {
        public Unit_InfoModel data { get; set; }
    }
    public class Unit_InfoModel
    {
        public UnitModel[] build_info { get; set; }
    }
    public class UnitModel
    {
        public string unit_id { get; set; }
        public string unit_no { get; set; }
        public string unit_addr { get; set; }
        public string build_id { get; set; }
    }

    public class HouResponse : ESQCommResponse
    {
        public Hou_InfoModel data { get; set; }
    }
    public class Hou_InfoModel
    {
        public HouModel[] build_info { get; set; }
    }
    public class HouModel
    {
        public string hou_id { get; set; }
        public string build_id { get; set; }
        public string unit_id { get; set; }
        public string hou_no { get; set; }
        public string hou_addr { get; set; }
        public string hou_area { get; set; }
    }

    public class PayListResponse : ESQCommResponse
    {
        public PayList_InfoModel data { get; set; }
    }
    public class PayList_InfoModel
    {
        public string total_count { get; set; }
        public PayListModel[] bill_info { get; set; }
    }
    public class PayListModel
    {
        public string bill_id { get; set; }
        public string service_fee_name { get; set; }
        public string pay_mng_cell_id { get; set; }
        public string pay_cell_addr { get; set; }
        public string fee_price { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
    }
}
