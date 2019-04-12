using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Model
{
    public class CKOutDetailSummary
    {
        public Foresight.DataAccess.CKProudctOutDetail outdetail { get; set; }
        public List<Foresight.DataAccess.CKInOutSummary> inoutlist { get; set; }
    }
    public class CartOrderModel
    {
        public Foresight.DataAccess.Mall_Order order { get; set; }
        public List<Foresight.DataAccess.Mall_OrderItem> OrderItemList { get; set; }
    }
}