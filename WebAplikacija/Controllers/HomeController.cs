using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendingsBL.Entities;
using SpendingsBL.Interfaces;
using SpendingsBL.Services;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class HomeController : Controller
    {
        private ISpendingsService _SpendingsService;

        public HomeController (ISpendingsService SpendingsService)
        {
            _SpendingsService = SpendingsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            Purchases purchases = new Purchases();

            purchases.PurchasesList = _SpendingsService.GetSpendings();

            return View(purchases);
        }

        [HttpPost]
        public ActionResult Index(Purchases purchases)
        {
            _SpendingsService.AddSpending(purchases.Purchase);
            purchases.PurchasesList = _SpendingsService.GetSpendings();
            return View(purchases);
        }

        public ActionResult Delete(int id)
        {
            Purchases purchases = new Purchases();

            _SpendingsService.DeleteSpending(id);

            purchases.PurchasesList = _SpendingsService.GetSpendings();
            return View("Index", purchases);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
    }
}