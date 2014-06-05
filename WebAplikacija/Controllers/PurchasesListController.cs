using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendingsBL.Interfaces;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class PurchasesListController : Controller
    {
        private ISpendingsService _SpendingsService;

        public PurchasesListController(ISpendingsService SpendingsService)
        {
            _SpendingsService = SpendingsService;
        }

        public ActionResult Index()
        {
            PurchasesListModel purchasesList = new PurchasesListModel();
            purchasesList.PurchasesList = _SpendingsService.GetSpendings();
            return View(purchasesList);
        }
	}
}