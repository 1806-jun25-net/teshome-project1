using System;
using System.Collections.Generic;

namespace Project1.data
{
    public partial class Orders
    {
        public int LocationId { get; set; }
        public string Username { get; set; }
        public DateTime Ordertime { get; set; }
        public int Currentprice { get; set; }
        public int Orderid { get; set; }
        public int Cheesepizza { get; set; }
        public int Pepperonipizza { get; set; }
        public int Sausagepizza { get; set; }

        public Locations Location { get; set; }
        public Users UsernameNavigation { get; set; }
    }
}
