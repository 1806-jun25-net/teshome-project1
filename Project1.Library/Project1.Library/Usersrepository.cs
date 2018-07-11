using Microsoft.EntityFrameworkCore;
using Project1.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public class Usersrepository
    {

        private readonly Project1DBContext _db;

        public Usersrepository(Project1DBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<User> GetUsers()
        {
            // disable pointless tracking for performance
            return Mapper.Map(_db.Users.Include(r => r.Orders).AsNoTracking());
        }
        
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
