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
    [RequireHttps]
    [Authorize]
    public class PurchasesController : Controller
    {
        private ISpendingsService _SpendingsService;

        public PurchasesController (ISpendingsService SpendingsService)
        {
            _SpendingsService = SpendingsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            PurchasesModel purchases = new PurchasesModel();

            purchases.PurchasesList = _SpendingsService.GetSpendings();

            return View(purchases);
        }

        [HttpPost]
        public ActionResult Index(PurchasesModel purchases)
        {
            _SpendingsService.AddSpending(purchases.Purchase);
            purchases.PurchasesList = _SpendingsService.GetSpendings();
            return View(purchases);
        }

        public ActionResult Delete(int id)
        {
            PurchasesModel purchases = new PurchasesModel();

            _SpendingsService.DeleteSpending(id);

            purchases.PurchasesList = _SpendingsService.GetSpendings();
            return View("Index", purchases);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }       

        public ActionResult Edit(int id)
        {
            PurchasesModel purchases = new PurchasesModel();
            purchases.Purchase = _SpendingsService.FindSpending(id);
            return View(purchases);
        }

        [HttpPost]
        public ActionResult Edit(PurchasesModel purchases)
        {
            _SpendingsService.EditSpendings(purchases.Purchase);
            purchases.PurchasesList = _SpendingsService.GetSpendings();

            return View("Index", purchases);
        }
    }
}