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
        Dictionary<int, Pirkinys> pirkiniuDictionary = new Dictionary<int, Pirkinys>();

        [HttpGet]
        public ActionResult Index()
        {
            PirkiniuSarasas pirkiniuSarasas = new PirkiniuSarasas();
            Dictionary<int, Pirkinys> pirkiniuDictionary = new Dictionary<int, Pirkinys>();
           
            pirkiniuSarasas.PirkiniuDictionary = pirkiniuDictionary;
            pirkiniuSarasas.ReadDocument();

            return View(pirkiniuSarasas);
        }

        [HttpPost]
        public ActionResult Index(PirkiniuSarasas pirkiniuSarasas)
        {
            //ModelState.Clear();
            //Pirkinys pirkinys = new Pirkinys();
            //Dictionary<int, Pirkinys> pirkiniuDictionary = new Dictionary<int, Pirkinys>();

            pirkiniuSarasas.PirkiniuDictionary = pirkiniuDictionary;

            pirkiniuSarasas.WriteToDocument(pirkiniuSarasas.Pirkinys.Name, pirkiniuSarasas.Pirkinys.Price);
            pirkiniuSarasas.ReadDocument();
            return View(pirkiniuSarasas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
    }
}