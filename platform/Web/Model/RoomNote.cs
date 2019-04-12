using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Model
{
    public class RoomNote
    {
        public int ID { get; set; }
        public string CategoryNote { get; set; }
        public string RemarkNote { get; set; }
        public int CategoryID { get; set; }
    }
}