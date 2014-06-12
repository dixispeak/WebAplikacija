using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private PurchasesEntities spendingsContext = new PurchasesEntities();

        public List<Purchase> GetSpendings()
        {
             List<Purchase> purchasesList = spendingsContext.Purchases.ToList();

            return purchasesList;
        }

        public void DeleteSpending(int id)
        {
            Purchase purchase = FindSpending(id);

            spendingsContext.Purchases.Remove(purchase);

            spendingsContext.SaveChanges();
        }

        public void AddSpending(Purchase purchase)
        {
            spendingsContext.Purchases.Add(purchase);
            spendingsContext.SaveChanges();
        }

        public void EditSpendings(Purchase purchase)
        {
            spendingsContext.Entry(purchase).State = EntityState.Modified;
            spendingsContext.SaveChanges();
        }

        public Purchase FindSpending(int id)
        {
            Purchase purchase = spendingsContext.Purchases.Find(id);
            return purchase;
        }
    }
}
