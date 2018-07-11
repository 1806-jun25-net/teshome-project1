using Microsoft.EntityFrameworkCore;
using Project1.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public class Locationsrepository
    {
        private readonly Project1DBContext _db;

        public Locationsrepository(Project1DBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Location> GetLocations()
        {
            // disable pointless tracking for performance
            return Mapper.Map(_db.Locations.Include(r => r.Orders).AsNoTracking());
        }

        public void UpdateLocations(data.Locations update)
        {
           // calling Update would mark every property as Modified.
            // this way will only mark the changed properties as Modified.
            _db.Entry(_db.Locations.Find(update.Id)).CurrentValues.SetValues(Mapper.Map(update));
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
