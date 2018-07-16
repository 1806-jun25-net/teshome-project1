using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1WebApp.Models
{
    public class LocationWeb
    {
        public int Cheeseinventory { get; set; }
        public int Pepperoniinventory { get; set; }
        public int Sausageinventory { get; set; }
        public List<int> Orderhistory { get; set; } = new List<int>();
    }
}
