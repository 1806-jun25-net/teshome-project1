using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public interface IOrder
    {
        int locationID { get; set; }
        string username { get; set; }
        DateTime ordertime { get; set; }
        int cheesepizza { get; set; }
        int pepperonipizza { get; set; }
        int sausagepizza { get; set; }
        int currentprice { get; set; }
        int orderID { get; set; } 
       
    }
}
