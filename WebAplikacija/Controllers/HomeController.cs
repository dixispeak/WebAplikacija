using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Pirkiniai sarasas = new Pirkiniai();
            sarasas.PirkiniuSarasas = sarasas.ReadDocument();
            return View(sarasas);
        }

        [HttpPost]
        public ActionResult Index(Pirkiniai sarasas)
        {
            //ModelState.Clear();
            //sarasas.Name = "asda";
            sarasas.WriteToDocument(sarasas.Name);
            sarasas.PirkiniuSarasas = sarasas.ReadDocument();
            return View(sarasas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
    }
}