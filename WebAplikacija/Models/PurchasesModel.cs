using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SpendingsBL.Entities;
using SpendingsDAL;

namespace WebAplikacija.Models
{
    public class PurchasesModel
    {
        public Purchase Purchase { get; set; }
        public List<Purchase> PurchasesList { get; set; }
    }
}