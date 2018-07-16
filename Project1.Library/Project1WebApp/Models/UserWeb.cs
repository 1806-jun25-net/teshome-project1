using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1WebApp.Models
{
    public class UserWeb
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int defaultlocationID { get; set; }
        public List<int> userorderhistory { get; set; } = new List<int>();
        public string username { get; set; }

    }
}
