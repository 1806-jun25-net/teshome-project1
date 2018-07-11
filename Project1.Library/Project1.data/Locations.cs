using System;
using System.Collections.Generic;

namespace Project1.data
{
    public partial class Locations
    {
        public Locations()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public int Cheeseinventory { get; set; }
        public int Pepperoniinventory { get; set; }
        public int Sausageinventory { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
