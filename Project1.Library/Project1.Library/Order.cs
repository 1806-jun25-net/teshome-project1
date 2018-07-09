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
        int maxprice = 500;
       public int cc = 0;
       public int pc = 0;
       public int sc = 0;

        

        public string addcheesepizza()
        {
            if (currentprice +c > maxprice)
            {

                return "Maximum Price reached.";

            }

           

            pizzalist.Add("c");
            currentprice += c;
            cc++;
            return "Cheese Pizza added";
        }

        public string addpepperonipizza()
        {

            if (currentprice + p > maxprice)
            {

                return "Maximum Price reached.";

            }

            pizzalist.Add("p");
            currentprice += p;
            pc++;
            return "Pepperoni Pizza added";
        }

        public string addsausagepizza()
        {

            if (currentprice + s > maxprice)
            {

                return "Maximum Price reached.";

            }

            pizzalist.Add("s");
            currentprice += s;
            sc++;
            return "Sausage Pizza added";
        }


        public bool Inventorycheck(Location loc)
        {
            if(cc <= loc.Ingredients[0] && pc <= loc.Ingredients[1] && sc<= loc.Ingredients[2])
            {
                return true;
            }

            else
            {
                return false;
            }
            
        }


       /* private string removepizza(int removevalue)
        {
            pizzalist.Remove();
            return "Pizza removed";
        }*/

      


    }
}
