using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            monthlyBillsModel.MonthlyBillsList = _MonthlyBillsService.GetNotPayedMonthlyBills();

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
            if (ModelState.IsValid)
            {
                _SpendingsService.AddSpending(purchasesMonthlyBills.PurchasesModel.Purchase);
                purchasesMonthlyBills.PurchasesModel.PurchasesList = _SpendingsService.GetSpendings();

                MonthlyBillsModel monthlyBillsModel = new MonthlyBillsModel();

                monthlyBillsModel.MonthlyBillsList = _MonthlyBillsService.GetNotPayedMonthlyBills();
                purchasesMonthlyBills.MonthlyBillsModel = monthlyBillsModel;
            }
            
            return View(purchasesMonthlyBills);
        }

        public ActionResult MonthlyBills(string[] billDescriptionID, PurchasesMonthlyBillsModel purchasesMonthlyBills)
        {
            if (ModelState.IsValid)
            {
                PurchasesModel purchasesModel = new PurchasesModel();
                MonthlyBillsModel monthlyBillsModel = new MonthlyBillsModel();

                purchasesModel.PurchasesList = _SpendingsService.GetSpendings();

                if (billDescriptionID != null)
                {
                    for (int i = 0; i < billDescriptionID.Length; i++)
                    {
                        _MonthlyBillsService.AddPayedBillMonth(Convert.ToInt32(billDescriptionID[i]));
                    }
                }

                monthlyBillsModel.MonthlyBillsList = _MonthlyBillsService.GetNotPayedMonthlyBills();

                purchasesMonthlyBills.PurchasesModel = purchasesModel;
                purchasesMonthlyBills.MonthlyBillsModel = monthlyBillsModel;
            }
            return View("Index", purchasesMonthlyBills);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchasesModel purchasesModel = new PurchasesModel();
            MonthlyBillsModel monthlyBillsModel = new MonthlyBillsModel();

            _SpendingsService.DeleteSpending(id);

            purchasesModel.PurchasesList = _SpendingsService.GetSpendings();
            monthlyBillsModel.MonthlyBillsList = _MonthlyBillsService.GetNotPayedMonthlyBills();

            PurchasesMonthlyBillsModel purchasesMonthlyBills = new PurchasesMonthlyBillsModel
            {
                PurchasesModel = purchasesModel,
                MonthlyBillsModel = monthlyBillsModel
            };
            return View("Index", purchasesMonthlyBills);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }       

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchasesModel purchasesModel = new PurchasesModel();
            MonthlyBillsModel monthlyBillsModel = new MonthlyBillsModel();

            PurchasesMonthlyBillsModel purchasesMonthlyBills = new PurchasesMonthlyBillsModel();

            purchasesModel.PurchasesList = _SpendingsService.GetSpendings();
            monthlyBillsModel.MonthlyBillsList = _MonthlyBillsService.GetNotPayedMonthlyBills();

            purchasesModel.Purchase = _SpendingsService.FindSpending(id);            

            purchasesMonthlyBills.PurchasesModel = purchasesModel;
            purchasesMonthlyBills.MonthlyBillsModel = monthlyBillsModel;

            return View(purchasesMonthlyBills);
        }

        [HttpPost]
        public ActionResult Edit(PurchasesMonthlyBillsModel purchasesMonthlyBills)
        {
            PurchasesModel purchasesModel = new PurchasesModel();
            MonthlyBillsModel monthlyBillsModel = new MonthlyBillsModel();

            _SpendingsService.EditSpendings(purchasesMonthlyBills.PurchasesModel.Purchase);

            purchasesModel.PurchasesList = _SpendingsService.GetSpendings();
            monthlyBillsModel.MonthlyBillsList = _MonthlyBillsService.GetNotPayedMonthlyBills();

            purchasesMonthlyBills.PurchasesModel = purchasesModel;
            purchasesMonthlyBills.MonthlyBillsModel = monthlyBillsModel;

            return View("Index", purchasesMonthlyBills);
        }
    }
}