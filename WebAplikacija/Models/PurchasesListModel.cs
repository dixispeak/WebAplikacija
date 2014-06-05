using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpendingsDAL;

namespace WebAplikacija.Models
{
    public class PurchasesListModel
    {
        public List<Purchase> PurchasesList { get; set; }
    }
}