using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public class Order : IOrder
    {
        public string locationID { get; set; }
        public string username { get; set; }
        public DateTime ordertime { get; set; }
        public List<string> pizzalist { get; set; } = new List<string>();
        public int currentprice { get; set; }
        public int orderID { get; set; }

        int c = 50;
        int p = 40;
        int s = 30;

        public string addcheesepizza()
        {
            pizzalist.Add("c");
            currentprice += c;
            return "Cheese Pizza added";
        }

        public string addpepperonipizza()
        {
            pizzalist.Add("p");
            currentprice += p;
            return "Pepperoni Pizza added";
        }

        public string addsausagepizza()
        {
            pizzalist.Add("s");
            currentprice += s;
            return "Sausage Pizza added";
        }

       /* private string removepizza(int removevalue)
        {
            pizzalist.Remove();
            return "Pizza removed";
        }*/

      


    }
}
