using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Library;

namespace Project1WebApp.Controllers
{
    public class OrderController : Controller
    {
        public OrderController(Ordersrepository pork, Usersrepository local, Locationsrepository lala)
        {
            beef = pork;
            userepo = local;
            locrepo = lala;
        }

        public Ordersrepository beef {get; set;}
        public Usersrepository userepo { get; set; }
        public Locationsrepository locrepo { get; set; }
        
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.OrderWeb oddweb)
        {
            if (!ModelState.IsValid)
            {
                return View(oddweb);

            }

            
            oddweb.currentprice = ((beef.c * oddweb.cheesepizza) + (beef.p * oddweb.pepperonipizza) + (beef.s * oddweb.sausagepizza));
            oddweb.username = (string)TempData.Peek("username");
            oddweb.ordertime = DateTime.Now;
            oddweb.orderID = beef.getneworderid();

            Project1.Library.Order orderobject = new Project1.Library.Order
            {
                locationID = oddweb.locationID,
                username = oddweb.username,
                ordertime = oddweb.ordertime,
                cheesepizza = oddweb.cheesepizza,
                pepperonipizza = oddweb.pepperonipizza,
                sausagepizza = oddweb.sausagepizza,
                currentprice = oddweb.currentprice,
                orderID = oddweb.orderID
            };

            // TODO: Add insert logic here


           

            if (orderobject.currentprice > orderobject.maxprice)
             {

                ViewData["Error"] = "Maximum Price Reached";
                return View(oddweb);


             }

            if ((orderobject.cheesepizza + orderobject.pepperonipizza + orderobject.sausagepizza) < 1)
            {
                ViewData["Error"] = "You have to put in at least one pizza";
                return View(oddweb);
            }


            if ((orderobject.cheesepizza + orderobject.pepperonipizza + orderobject.sausagepizza) > 12)
            {
                ViewData["Error"] = "Maximum Pizza's Exceeded";
                return View(oddweb);
            }







            try
            {



                Order p = (beef.OID(userepo.Unub((string)TempData.Peek("username")).userorderhistory.Last(d => beef.OID(d).locationID == orderobject.locationID)));



                DateTime.Compare(p.ordertime.AddHours(2), DateTime.Now);

                if (DateTime.Compare(p.ordertime.AddHours(2), DateTime.Now) > 0)
                {
                    ViewData["Error"] = ("You cannot place an order at this location for another 2 Hours. Goodbye");
                    return View(oddweb);
                }
            }

            catch(Exception e)
            {
                
            }

            //send order history to order history page

                
            var locobject = locrepo.GetLocations().ToList()[orderobject.locationID];

            if (!beef.Inventorycheck(locobject, orderobject))
            {
                ViewData["Error"] = "Not enough Ingredients";
                return View(oddweb);
            }

            locobject.Cheeseinventory -= orderobject.cheesepizza;
            locobject.Pepperoniinventory -= orderobject.pepperonipizza;
            locobject.Sausageinventory -= orderobject.sausagepizza;

            locrepo.UpdateLocations(Mapper.Map(locobject));

            beef.AddOrders(Mapper.Map(orderobject));
                beef.Save();

     



            return View(nameof(confirmationpage), oddweb);


        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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

        public ActionResult confirmationpage()
        {
            TempData["uservari"] = "mimvdofg";
            return View();
        }


    }
}