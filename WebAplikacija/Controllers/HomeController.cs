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
        [HttpGet]
        public ActionResult Index()
        {
            ISpendingsService spendingsService = new SpendingsService();

            Purchases purchases = new Purchases();

            purchases.PurchasesList = spendingsService.GetSpendings();

            return View(purchases);
        }

        [HttpPost]
        public ActionResult Index(Purchases purchases)
        {
            ISpendingsService spendingsService = new SpendingsService();

            spendingsService.AddSpending(purchases.Purchase);
            purchases.PurchasesList = spendingsService.GetSpendings();
            return View(purchases);
        }

        public ActionResult Delete(int id)
        {
            ISpendingsService spendingsService = new SpendingsService();
            Purchases purchases = new Purchases();

            spendingsService.DeleteSpending(id);

            purchases.PurchasesList = spendingsService.GetSpendings();
            return View("Index", purchases);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
    }
}