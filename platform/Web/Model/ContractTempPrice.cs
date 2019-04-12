using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Model
{
    public class ContractTempPrice
    {
        public int ID { get; set; }
        public decimal CalculatePrice { get; set; }
        public DateTime CalculateStartTime { get; set; }
        public DateTime CalculateEndTime { get; set; }
        public DateTime ReadyChargeTime { get; set; }
        public decimal CalculateCost { get; set; }
    }
}