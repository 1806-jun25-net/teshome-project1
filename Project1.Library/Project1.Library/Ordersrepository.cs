using Microsoft.EntityFrameworkCore;
using Project1.data;
using System;
using System.Collections.Generic;
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


        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
