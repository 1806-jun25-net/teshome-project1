using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Library;

namespace Project1WebApp.Controllers
{
    public class OrderHistoryController : Controller
    {

        public OrderHistoryController(Ordersrepository pork, Usersrepository local)
        {
            beef = pork;
            userepo = local;
        }

        public Ordersrepository beef { get; set; }
        public Usersrepository userepo { get; set; }

        // GET: OrderHistory
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderHistory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderHistory/Create
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

        // GET: OrderHistory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderHistory/Edit/5
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

        // GET: OrderHistory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderHistory/Delete/5
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

        public ActionResult Orderhistory(string button)
        {
            switch (button)
            {
                case "Earliest":
                    return View(beef.GetOrders().OrderBy(o => o.ordertime));
                    break;
                case "Latest":
                    return View(beef.GetOrders().OrderByDescending(o => o.ordertime));
                    break;
                case "Cheapest":
                    return View(beef.GetOrders().OrderBy(o => o.currentprice));
                    break;
                case "Most Expensive":
                    return View(beef.GetOrders().OrderByDescending(o => o.currentprice));
                    break;
               
            }
            return View(beef.GetOrders());


        }
    }
}