using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public class Location : ILocation
    {
        public List<int> Ingredients { get; set; } = new List<int>();
        public List<int> Orderhistory { get; set; } = new List<int>();

        public Location()
        {
            Ingredients.Add(5);//cheese inventory
            Ingredients.Add(5);//pepperoni inventory
            Ingredients.Add(5);//sausage inventory
        }

    }

   
    



        








    
}
