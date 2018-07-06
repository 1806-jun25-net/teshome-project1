using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public interface IUser
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        int locationID { get; set; }


    }
}
