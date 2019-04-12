using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class RoomFeeChangeField
    {
        public int ID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UseCount { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public decimal RealCost { get; set; }
        public int OutDays { get; set; }
        public string Remark { get; set; }
        public decimal ChargeFee { get; set; }
        public string NewEndTime { get; set; }
        public int DiscountID { get; set; }
    }
}
