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
            PirkiniuSarasas sarasas = new PirkiniuSarasas();
            sarasas.PirkiniuDictionary = sarasas.ReadDocument();
            return View(sarasas);
        }

        [HttpPost]
        public ActionResult Index(PirkiniuSarasas sarasas)
        {
            //ModelState.Clear();
            
            string _name = sarasas.Name;
            decimal _price = sarasas.Price;

            sarasas.WriteToDocument(_name, _price);
            sarasas.PirkiniuDictionary = sarasas.ReadDocument();
            return View(sarasas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
    }
}