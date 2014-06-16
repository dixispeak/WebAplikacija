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
        private IMonthlyBillsService _MonthlyBillsService;

        public PurchasesController(ISpendingsService SpendingsService, IMonthlyBillsService MonthlyBillsService)
        {
            _SpendingsService = SpendingsService;
            _MonthlyBillsService = MonthlyBillsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            PurchasesModel purchasesModel = new PurchasesModel();
            MonthlyBillsModel monthlyBillsModel = new MonthlyBillsModel();

            purchasesModel.PurchasesList = _SpendingsService.GetSpendings();
            monthlyBillsModel.MonthlyBillsList = _MonthlyBillsService.GetNotPayedMonthlyBills(DateTime.Today);

            PurchasesMonthlyBillsModel purchasesMonthlyBills = new PurchasesMonthlyBillsModel
            { 
                PurchasesModel = purchasesModel,
                MonthlyBillsModel = monthlyBillsModel
            };

            return View(purchasesMonthlyBills);
        }

        [HttpPost]
        public ActionResult Index(PurchasesMonthlyBillsModel purchasesMonthlyBills)
        {
            _SpendingsService.AddSpending(purchasesMonthlyBills.PurchasesModel.Purchase);
            purchasesMonthlyBills.PurchasesModel.PurchasesList = _SpendingsService.GetSpendings();

            MonthlyBillsModel monthlyBillsModel = new MonthlyBillsModel();
            var now = DateTime.Now;
            var today = new DateTime(now.Year, now.Month, 1);
            monthlyBillsModel.MonthlyBillsList = _MonthlyBillsService.GetNotPayedMonthlyBills(today);
            purchasesMonthlyBills.MonthlyBillsModel = monthlyBillsModel;
            
            return View(purchasesMonthlyBills);
        }

        public ActionResult MonthlyBills(PurchasesMonthlyBillsModel purchasesMonthlyBills)
        {
            PurchasesModel purchasesModel = new PurchasesModel();
            MonthlyBillsModel monthlyBillsModel = new MonthlyBillsModel();

            purchasesModel.PurchasesList = _SpendingsService.GetSpendings();


            monthlyBillsModel.MonthlyBillsList = _MonthlyBillsService.GetNotPayedMonthlyBills(DateTime.Today);

            purchasesMonthlyBills.PurchasesModel = purchasesModel;
            purchasesMonthlyBills.MonthlyBillsModel = monthlyBillsModel;
            return View(purchasesMonthlyBills);
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