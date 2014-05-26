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

            PurchasesList purchasesList = new PurchasesList();

            purchasesList.PurchaseDictionary = spendingsService.GetSpendings();

            return View(purchasesList);
        }

        [HttpPost]
        public ActionResult Index(PurchasesList purchasesList)
        {
            ISpendingsService spendingsService = new SpendingsService();

            spendingsService.AddSpending(purchasesList.Purchase.Name, purchasesList.Purchase.Price);
            purchasesList.PurchaseDictionary= spendingsService.GetSpendings();
            return View(purchasesList);
        }

        public ActionResult Delete(int id)
        {
            ISpendingsService spendingsService = new SpendingsService();
            PurchasesList purchasesList = new PurchasesList();

            spendingsService.DeleteSpending(id);

            purchasesList.PurchaseDictionary = spendingsService.GetSpendings();
            return View("Index", purchasesList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
    }
}