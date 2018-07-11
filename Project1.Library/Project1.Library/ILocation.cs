using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public interface ILocation
    {
        int Cheeseinventory { get; set; }
        int Pepperoniinventory { get; set; }
        int Sausageinventory { get; set; }
        List<int> Orderhistory { get; set; }
    }
}
