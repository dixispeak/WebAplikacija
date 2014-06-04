using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendingsBL.Entities;
using SpendingsBL.Interfaces;
using SpendingsDAL;

namespace SpendingsBL.Services
{
    public class SpendingsService : ISpendingsService
    {

        public List<Purchase> GetSpendings()
        {
            PurchasesEntities spendingsContext = new PurchasesEntities();

             List<Purchase> purchasesList = spendingsContext.Purchases.ToList();

            return purchasesList;
        }

        public void DeleteSpending(int id)
        {
            PurchasesEntities spendingsContext = new PurchasesEntities();

            Purchase purchase = spendingsContext.Purchases.Find(id);

            spendingsContext.Purchases.Remove(purchase);

            spendingsContext.SaveChanges();
        }

        public void AddSpending(Purchase purchase)
        {
            PurchasesEntities spendingsContext = new PurchasesEntities();

            spendingsContext.Purchases.Add(purchase);
            spendingsContext.SaveChanges();
        }
    }
}
