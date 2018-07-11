using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public class Order : IOrder
    {
        public int locationID { get; set; }
        public string username { get; set; }
        public DateTime ordertime { get; set; }
        public int cheesepizza { get; set; }
        public int pepperonipizza { get; set; }
        public int sausagepizza { get; set; }
        public int currentprice { get; set; }
        public int orderID { get; set; }

        int c = 50;
        int p = 40;
        int s = 30;
        int maxprice = 500;
       

        

        public string addcheesepizza()
        {
            if (currentprice +c > maxprice)
            {

                return "Maximum Price reached.";

            }

            currentprice += c;
            cheesepizza++;
            return "Cheese Pizza added";
        }

        public string addpepperonipizza()
        {

            if (currentprice + p > maxprice)
            {

                return "Maximum Price reached.";

            }

            currentprice += p;
            pepperonipizza++;
            return "Pepperoni Pizza added";
        }

        public string addsausagepizza()
        {

            if (currentprice + s > maxprice)
            {

                return "Maximum Price reached.";

            }

            currentprice += s;
            sausagepizza++;
            return "Sausage Pizza added";
        }


        public bool Inventorycheck(Location loc)
        {
            if(cheesepizza <= loc.Cheeseinventory && pepperonipizza <= loc.Pepperoniinventory && sausagepizza<= loc.Sausageinventory)
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
