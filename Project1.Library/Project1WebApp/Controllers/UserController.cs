using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
using Project1.Library;
using Project1WebApp.Models;

namespace Project1WebApp.Controllers
{
    public class UserController : Controller
    {
        public UserController(Usersrepository ur, DataList dul, Ordersrepository por)
        {
            Lur = ur;
            dl = dul;
            or = por;
        }

        public Usersrepository Lur { get; set; } 

        public DataList dl { get; set; }

        public Ordersrepository or { get; set; }
 
       

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Usersearchpageredirect()
        {            

            return View(nameof (Usersearchpage));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Usersearchpage(string myTextBox)
        {

            

            User w = Lur.Unub(myTextBox);
            string f = Lur.Unub(myTextBox).username;

            var otm = new UserWeb
            {

                Firstname = w.Firstname,
                Lastname = w.Lastname,
                defaultlocationID = w.defaultlocationID,
                userorderhistory = w.userorderhistory,
                username = w.username

            };
           

            return View(nameof (Details), otm);
            
           
           
        }

        public ActionResult SuggestedOrderView(string myTextBox)
        {
            Order sss;
            User placeholderforusername = dl.Unub(myTextBox);
            if (placeholderforusername.userorderhistory.Count == 0)
            {
                sss = new Order()
                { cheesepizza = 1, pepperonipizza = 1, sausagepizza = 1
                };
                    
            
            }
            else
            {
                sss = dl.OID(placeholderforusername.userorderhistory.Last());
            }   
               
                TempData["username"] = myTextBox;


            var owo = new OrderWeb
            {

                locationID = sss.locationID,
                username =  sss.username, 
                ordertime = sss.ordertime, 
                cheesepizza = sss.cheesepizza,
                pepperonipizza = sss.pepperonipizza,
                sausagepizza = sss.sausagepizza,
                currentprice = sss.currentprice,
                orderID = sss.orderID

            };

           List<Order> ol = or.GetOrders().Where(q => q.username.Equals(myTextBox)).ToList();

            List<OrderWeb> owl = new List<OrderWeb>(); 
             
            foreach (var oml in ol)
            {
                owl.Add(new OrderWeb
                {

                    locationID = sss.locationID,
                    username = sss.username,
                    ordertime = sss.ordertime,
                    cheesepizza = sss.cheesepizza,
                    pepperonipizza = sss.pepperonipizza,
                    sausagepizza = sss.sausagepizza,
                    currentprice = sss.currentprice,
                    orderID = sss.orderID

                });
            }

            return View(owl);
        } 



    }
}






