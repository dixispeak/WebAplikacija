using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SpendingsBL.Entities;

namespace WebAplikacija.Models
{
    public class PurchasesList
    {
        public PurchaseEntity Purchase { get; set; }
        public Dictionary<int, PurchaseEntity> PurchaseDictionary { get; set; }
    }
}