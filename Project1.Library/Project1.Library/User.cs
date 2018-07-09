using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{


    public class User : IUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int defaultlocationID { get; set; }
        public List<int> userorderhistory { get; set; } = new List<int>();
        public string username { get; set; }

        public User(string un, string fn, string ln, int did)
        {
            Firstname = fn;
            Lastname = ln;
            defaultlocationID = did;
            username = un;


        }

        public User()
        {

        }
       



    }

    
     
}
