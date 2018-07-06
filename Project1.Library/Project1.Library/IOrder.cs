using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public interface IOrder
    {
        string locationID { get; set; }
        string username { get; set; }
        DateTime ordertime { get; set; }
        List<string> pizzalist { get; set; }
        int currentprice { get; set; }
        int orderID { get; set; } 
       
    }
}
