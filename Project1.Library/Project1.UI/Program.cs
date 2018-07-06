using Project1.Library;
using System;
using System.Collections.Generic;

namespace Project1.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User firstname = new User();
            User lastname = new User();
            Order orderobject = new Order();

            // Begninning, the user inputs their name
            Console.WriteLine("Enter your First and Last name");
            string name = Console.ReadLine();
            orderobject.username = name;

            //First User picks a location based on the location ID
            Console.WriteLine("Pick a Location, Input #0 or #1");
            string input = Console.ReadLine();


            do
            {

                switch (input)
                {
                    case "0":
                        Console.WriteLine("Location #0 confirmed");
                        break;
                    case "1":
                        Console.WriteLine("Location #1 confirmed");
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
                
            }

            while (!input.Equals("0") || !input.Equals("1"));

            orderobject.locationID = input;



            //if they input 0 or 1, move onto the ordering part.
            //also if they input anything else, give an error message
            //Console.WriteLine("Invalid Entry");



            //Second the User goes into the order function and starts making their order

            string order;
            do
            {
                Console.WriteLine("What kind of pizza do you want? Input c for cheese, p for pepperoni, or s for sausage, Input f, when you are done ordering");
                order = Console.ReadLine();

                switch (order)
                {
                    case "c":
                        Console.WriteLine(orderobject.addcheesepizza());
                        break;
                    case "p":
                        Console.WriteLine(orderobject.addpepperonipizza()); 
                        break;
                    case "s":
                        Console.WriteLine(orderobject.addsausagepizza());
                        break;
                    case "f":
                        Console.WriteLine($"Order Price {orderobject.currentprice}");
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
            }

            while (!order.Equals("f"));
            

            //then complete the order by submitting it to the orderlist
            DataList dl = new DataList();
            dl.Orderlist.Add(orderobject);
            //Order.orderID(orderobject);


            
            //update order objec( nameoforder.name of variableex locaiton, user)
            //datetiem use code for 2 hours ahead


          
        }


           
        
    }
}
