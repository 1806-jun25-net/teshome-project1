using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public class Location : ILocation
    {
        public int Cheeseinventory { get; set; }
        public int Pepperoniinventory { get; set; }
        public int Sausageinventory { get; set; }
        public List<int> Orderhistory { get; set; } = new List<int>();

        public Location()
        {
            Cheeseinventory = (5);//cheese inventory
            Pepperoniinventory = (5);//pepperoni inventory
            Sausageinventory = (5);//sausage inventory
        }

    }

   
    



        








    
}
