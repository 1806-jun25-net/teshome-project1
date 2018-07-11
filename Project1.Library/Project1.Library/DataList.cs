using Project1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Project1.Library
{
    public class DataList
    {
        public List<Order> Orderlist { get; set; } = new List<Order>();
        public List<Location> Locationlist { get; set; } = new List<Location>();
        public List<User> Userlist { get; set; } = new List<User>();
        

        [XmlIgnore]
        public Usersrepository ur;
        [XmlIgnore]
        public Ordersrepository or;
        [XmlIgnore]
        public Locationsrepository lr;
        

        public DataList()
        {
            Locationlist.Add(new Location());
            Locationlist.Add(new Location());
            Userlist.Add(new User("user1", "bob", "barker", 0));
            Userlist.Add(new User("user2", "kate", "cake", 1));  

        }


        public DataList(Project1DBContext dbc)
        {
            ur = new Usersrepository(dbc);
            or = new Ordersrepository(dbc);
            lr = new Locationsrepository(dbc);

            Userlist = ur.GetUsers().ToList();
            Orderlist = or.GetOrders().ToList();
            Locationlist = lr.GetLocations().ToList();


        }

        private int counter = 0;

        public int getneworderid()
        {
            counter++;

            return counter;
        }
        
        //user name user object
        public User Unub(string k)
        {

            for (int v = 0; v < Userlist.Count; v++)
            {

                
                if (Userlist[v].username.Equals(k))
                {
                    return Userlist[v];
                }

            }

            return null;

        }

        // Order ID lookup
        public Order OID(int k)
        {

            for (int v = 0; v < Orderlist.Count; v++)
            {


                if (Orderlist[v].orderID == (k))
                {
                    return Orderlist[v];
                }

            }

            return null;

        }

    }
}
