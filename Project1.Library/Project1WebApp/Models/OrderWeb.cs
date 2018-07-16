using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1WebApp.Models
{
    public class OrderWeb
    {
        public int locationID { get; set; }
        public string username { get; set; }
        public DateTime ordertime { get; set; }
        public int cheesepizza { get; set; }
        public int pepperonipizza { get; set; }
        public int sausagepizza { get; set; }
        public int currentprice { get; set; }
        public int orderID { get; set; }

    }
}
