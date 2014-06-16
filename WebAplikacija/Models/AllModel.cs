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

    public class MonthlyBillsModel
    {
        public MonthlyBill Bill { get; set; }
        public List<MonthlyBill> MonthlyBillsList { get; set; }
    }

    public class PurchasesMonthlyBillsModel
    {
        public MonthlyBillsModel MonthlyBillsModel { get; set; }
        public PurchasesModel PurchasesModel { get; set; }
    }

    public class Bill 
    {
        public int BillDescriptionID { get; set; }
        public string BillDescription { get; set; }
        public bool IsDone { get; set; }

        public Bill(int billDescriptionID, string billDescription, bool isDone)
        {
            BillDescriptionID = billDescriptionID;
            BillDescription = billDescription;
            IsDone = isDone;
        }
    }
}