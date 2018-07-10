using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project1.data;
using Project1.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Project1.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configBuilder.Build();


            var optionsBuilder = new DbContextOptionsBuilder<Project1DBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("project1db"));
            var options = optionsBuilder.Options;

            DataList dl;

            Task<DataList> desListTask = Serialize.DeserializeFromFileAsync(@"C:\Revature\teshome-project1\Project1.Library\data.xml");
            DataList result = null;
            try
            {
                result = desListTask.Result; // synchronously sits around until the result is ready
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("file wasn't found");
            }

            if (result != null)
            {
                dl = result;
            }
            else
            {
                dl = new DataList();
            }

            Order orderobject = new Order();
            


            // Begninning, the user inputs their name
            Console.WriteLine("Enter your Username");
            string name = Console.ReadLine();
            orderobject.username = name;

            User placeholderforusername = dl.Unub(name);

            Console.WriteLine("Would you like to see your order history? Input yes or no");
            string input1;
            do
            {
                input1 = Console.ReadLine();
                switch (input1)
                {
                    case "yes":
                        for (int g = 0; g < placeholderforusername.userorderhistory.Count; g++)
                        {
                            Order currentorder = dl.OID(placeholderforusername.userorderhistory[g]);
                            Console.WriteLine($"Here is your Order History: Order ID{currentorder.orderID}, LocationID: {currentorder.locationID}, User{currentorder.username}, Order Details, Chesse: {currentorder.cc}, Pepperoni: {currentorder.pc}, Sausage:{currentorder.sc}");
                        }
                        break;
                    case "no":
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }

            }

            while (!(input1.Equals("yes") || input1.Equals("no")));

            //First User picks a location based on the location ID
            Console.WriteLine("Pick a Location, Input #0 or #1");
            string input;

            do
            {
                input = Console.ReadLine();
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

            while (!(input.Equals("0") || input.Equals("1")));

            orderobject.locationID = input;


            Console.WriteLine("Would you like to access this location's order history? Input yes or no");
            string input2;
            do
            {
                input2 = Console.ReadLine();
                switch (input2)
                {
                    case "yes":
                        for (int g = 0; g < dl.Locationlist[Int32.Parse(input)].Orderhistory.Count; g++)
                        {
                            Order currentorder = dl.OID(dl.Locationlist[Int32.Parse(input)].Orderhistory[g]);
                            Console.WriteLine($"Here is your Order History: Order ID{currentorder.orderID}, LocationID: {currentorder.locationID}, User{currentorder.username}, Order Details, Chesse: {currentorder.cc}, Pepperoni: {currentorder.pc}, Sausage:{currentorder.sc}");
                        }
                        break;
                    case "no":
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }

            }

            while (!(input2.Equals("yes") || input2.Equals("no")));


            //if they input 0 or 1, move onto the ordering part.
            //also if they input anything else, give an error message
            //Console.WriteLine("Invalid Entry");



            //Second the User goes into the order function and starts making their order


            string order;
            bool exitmenu = false;

            for (int i = 1; i < 13; i++)
            {
                Console.WriteLine("What kind of pizza do you want? Input c for cheese, p for pepperoni, or s for sausage, Input f, when you are done ordering, NOTE: you can only order 12 pizzas MAXIMUM");
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
                        exitmenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        i--;
                        break;
                }

                Console.WriteLine($"Order Price {orderobject.currentprice}");

                if (exitmenu) 
                {
                break;
                }

            }

            if(orderobject.Inventorycheck((dl.Locationlist[Int32.Parse(orderobject.locationID)])) == true)
            {
                Console.WriteLine($"Order submitted at {orderobject.ordertime = DateTime.Now} at {orderobject.locationID} by {orderobject.username}");
                Console.WriteLine("Order Submitted to Orderlist");
                orderobject.orderID = dl.getneworderid();
                dl.Locationlist[Int32.Parse(input)].Orderhistory.Add(orderobject.orderID);
                dl.Unub(name).userorderhistory.Add(orderobject.orderID);
                dl.Orderlist.Add(orderobject);

                // add when SQL is working ((dl.Locationlist[Int32.Parse(orderobject.locationID)]));
                //Give Order ID in SQL
            }
            else
            {
                Console.WriteLine("Insuffiecient Inventory");
            }

            Serialize.SerializeToFile(@"C:\Revature\teshome-project1\Project1.Library\data.xml", dl);




            //add to order history

            //Order.orderID(orderobject);




            //datetiem use code for 2 hours ahead



        }


           
        
    }
}
