using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpendingsBL.Interfaces;
using SpendingsDAL;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    [Authorize]
    public class MonthlyBillsController : Controller
    {
        private IMonthlyBillsService _MonthlyBillsService;

        public MonthlyBillsController(IMonthlyBillsService MonthlyBillsService)
        {
            _MonthlyBillsService = MonthlyBillsService;
        }

        // GET: /MonthlyBills/       
        public ActionResult Index()
        {
            MonthlyBillsModel monthlyBills = new MonthlyBillsModel();

            monthlyBills.MonthlyBillsList = _MonthlyBillsService.GetMonthlyBills();

            return View(monthlyBills);
        }

        // GET: /MonthlyBills/Details/5
        public ActionResult Details(int id)
        {
            MonthlyBillsModel monthlyBills = new MonthlyBillsModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            monthlyBills.Bill = _MonthlyBillsService.FindBill(id);
            if (monthlyBills.Bill == null)
            {
                return HttpNotFound();
            }
            return View(monthlyBills);
        }

        // GET: /MonthlyBills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MonthlyBills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MonthlyBillsModel monthlyBills)
        {
            if (ModelState.IsValid)
            {
                _MonthlyBillsService.AddBill(monthlyBills.Bill);
                return RedirectToAction("Index");
            }

            return View(monthlyBills);
        }

        // GET: /MonthlyBills/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyBillsModel monthlyBills = new MonthlyBillsModel();
            monthlyBills.Bill = _MonthlyBillsService.FindBill(id);
            if (monthlyBills == null)
            {
                return HttpNotFound();
            }
            return View(monthlyBills);
        }

        // POST: /MonthlyBills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MonthlyBillsModel monthlyBills)
        {
            if (ModelState.IsValid)
            {
                _MonthlyBillsService.EditBill(monthlyBills.Bill);
                return RedirectToAction("Index");
            }
            return View(monthlyBills);
        }

        // GET: /MonthlyBills/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyBillsModel monthlyBills = new MonthlyBillsModel();
            monthlyBills.Bill = _MonthlyBillsService.FindBill(id);
            if (monthlyBills == null)
            {
                return HttpNotFound();
            }
            return View(monthlyBills);
        }

        // POST: /MonthlyBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _MonthlyBillsService.DeleteBill(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
