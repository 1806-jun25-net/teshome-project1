using System;
using System.Collections.Generic;

namespace Project1.data
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Defaultlocationid { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
