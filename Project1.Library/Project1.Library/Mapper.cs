using Project1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Library
{
    public static class Mapper
    {
        
        public static User Map(data.Users item) => new User
        {
            defaultlocationID = item.Defaultlocationid,
            Firstname = item.Firstname,
            Lastname = item.Lastname,
            username = item.Username,
            userorderhistory = item.Orders.Select(x => x.Orderid).ToList()
        };

        public static data.Users Map(User item) => new data.Users
        {
            Defaultlocationid = item.defaultlocationID,
            Firstname = item.Firstname,
            Lastname = item.Lastname,
            Username = item.username,

        };

        public static Order Map(data.Orders ret) => new Order
        {
            locationID = ret.LocationId,
            username = ret.Username,
            ordertime = ret.Ordertime,
            cheesepizza = ret.Cheesepizza,
            pepperonipizza = ret.Pepperonipizza,
            sausagepizza = ret.Sausagepizza,
            currentprice = ret.Currentprice,
            orderID = ret.Orderid
        };

        public static data.Orders Map(Order ret) => new data.Orders
        {
            LocationId = ret.locationID,
            Username = ret.username,
            Ordertime = ret.ordertime,
            Cheesepizza = ret.cheesepizza,
            Pepperonipizza = ret.pepperonipizza,
            Sausagepizza = ret.sausagepizza,
            Currentprice = ret.currentprice,
            Orderid = ret.orderID
        };

        
        public static Location Map(data.Locations tock) => new Location
        {
            Cheeseinventory = tock.Cheeseinventory,
            Pepperoniinventory = tock.Pepperoniinventory,
            Sausageinventory = tock.Sausageinventory,
            Orderhistory = tock.Orders.Select(x => x.Orderid).ToList(),
            Id = tock.Id
        };

        
        public static data.Locations Map(Location tock) => new data.Locations
        {
            Cheeseinventory = tock.Cheeseinventory,
            Pepperoniinventory = tock.Pepperoniinventory,
            Sausageinventory = tock.Sausageinventory,
            Id = tock.Id
    };
        
        public static IEnumerable<User> Map(IEnumerable<data.Users> item) => item.Select(Map);

        public static IEnumerable<data.Users> Map(IEnumerable<User> item) => item.Select(Map);

        public static IEnumerable<Order> Map(IEnumerable<data.Orders> ret) => ret.Select(Map);

        public static IEnumerable<data.Orders> Map(IEnumerable<Order> ret) => ret.Select(Map);

        public static IEnumerable<Location> Map(IEnumerable<data.Locations> tock) => tock.Select(Map);

        public static IEnumerable<data.Locations> Map(IEnumerable<Location> tock) => tock.Select(Map);
        
        
    }
}

