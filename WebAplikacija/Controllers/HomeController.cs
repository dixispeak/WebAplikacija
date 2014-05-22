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
            PirkiniuSarasas pirkiniuSarasas = new PirkiniuSarasas();

            pirkiniuSarasas.PirkiniuDictionary = pirkiniuSarasas.ReadDocument();

            return View(pirkiniuSarasas);
        }

        [HttpPost]
        public ActionResult Index(PirkiniuSarasas pirkiniuSarasas)
        {
            //ModelState.Clear();
            //Pirkinys pirkinys = new Pirkinys();
            //Dictionary<int, Pirkinys> pirkiniuDictionary = new Dictionary<int, Pirkinys>();
            pirkiniuSarasas.WriteToDocument(pirkiniuSarasas.Pirkinys.Name, pirkiniuSarasas.Pirkinys.Price);
            pirkiniuSarasas.PirkiniuDictionary = pirkiniuSarasas.ReadDocument();
            return View(pirkiniuSarasas);
        }

        public ActionResult Delete(int id)
        {
            PirkiniuSarasas pirkiniuSarasas = new PirkiniuSarasas();
            pirkiniuSarasas.Delete(id);

            pirkiniuSarasas.PirkiniuDictionary = pirkiniuSarasas.ReadDocument();
            return View("Index", pirkiniuSarasas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
    }
}