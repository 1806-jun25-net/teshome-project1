using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public interface ILocation
    {
          Dictionary<string, int> Ingredients { get; set; }
          List<int> Orderhistory { get; set; }


        

    }
}
