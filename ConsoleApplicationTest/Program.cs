using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendingsDAL;

namespace ConsoleApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerQuery();
        }

        private static void CustomerQuery()
        {
            //var context = new PurchasesEntities();
            //var query = context.Purchases.ToList();

            PurchasesEntities spendingsContext = new PurchasesEntities();

            Purchase purchaseEntity = new Purchase
            {
                Name = "Bananas",
                Price = 1.23m
            };

            spendingsContext.Purchases.Add(purchaseEntity);

            spendingsContext.SaveChanges();

            Purchase savePurchase = (from p in spendingsContext.Purchases where p.ID == purchaseEntity.ID select p).Single();
        }
    }
}
