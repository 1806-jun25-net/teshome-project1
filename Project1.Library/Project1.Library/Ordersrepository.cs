using Microsoft.EntityFrameworkCore;
using Project1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Library
{
    public class Ordersrepository
    {
        
        private readonly Project1DBContext _db;

        public Ordersrepository(Project1DBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        
        public IEnumerable<Order> GetOrders()
        {
            // disable pointless tracking for performance
            return Mapper.Map(_db.Orders.AsNoTracking());
        }

        public void AddOrders(data.Orders x)
        {
            _db.Add(x);
        }

        private int counter;
        public int getneworderid()
        {
            counter = GetOrders().Max(s => s.orderID);
            counter++;

            return counter;
        }

        
        public int c = 50;
        public int p = 40;
        public int s = 30;
        public int maxprice = 500;



        public void Save()
        {
            _db.SaveChanges();
        }

        // Order ID lookup
        public Order OID(int k)
        {
            var orderlist = GetOrders().ToList();

            for (int v = 0; v < orderlist.Count; v++)
            {


                if (orderlist[v].orderID == (k))
                {
                    return orderlist[v];
                }

            }

            return null;

        }



        public bool Inventorycheck(Location loc, Order o)
        {
            if (o.cheesepizza <= loc.Cheeseinventory && o.pepperonipizza <= loc.Pepperoniinventory && o.sausagepizza <= loc.Sausageinventory)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

    }
}
