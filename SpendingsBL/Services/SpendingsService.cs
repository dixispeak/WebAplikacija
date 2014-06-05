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

        public List<Purchase> GetSpendings()
        {
            PurchasesEntities spendingsContext = new PurchasesEntities();

             List<Purchase> purchasesList = spendingsContext.Purchases.ToList();

            return purchasesList;
        }

        public void DeleteSpending(int id)
        {
            PurchasesEntities spendingsContext = new PurchasesEntities();

            Purchase purchase = FindSpending(id);

            spendingsContext.Purchases.Remove(purchase);

            spendingsContext.SaveChanges();
        }

        public void AddSpending(Purchase purchase)
        {
            PurchasesEntities spendingsContext = new PurchasesEntities();

            spendingsContext.Purchases.Add(purchase);
            spendingsContext.SaveChanges();
        }

        public void EditSpendings(Purchase purchase)
        {
            PurchasesEntities spendingsContext = new PurchasesEntities();
            spendingsContext.Entry(purchase).State = EntityState.Modified;
            spendingsContext.SaveChanges();
        }

        public Purchase FindSpending(int id)
        {
            PurchasesEntities spendingsContext = new PurchasesEntities();

            Purchase purchase = spendingsContext.Purchases.Find(id);

            return purchase;
        }
    }
}
