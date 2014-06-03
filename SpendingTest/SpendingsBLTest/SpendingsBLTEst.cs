using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendingsDAL;
using SpendingsBL.Services;
using SpendingsBL.Interfaces;

namespace SpendingTest.SpendingsBL
{
    [TestFixture]
    class SpendingsBLTEst
    {
        Purchase purchaseEntity = new Purchase
        {
            ID = 1,
            Name = "Bananas",
            Price = 1.23m
        };

        ISpendingsService spendingsService = new SpendingsService();

        [Test]
        public void AddSpendingTest()
        {
            spendingsService.AddSpending(purchaseEntity);
        }

        [Test]
        public void GetSpendingsTest()
        {
            List<Purchase> purchasesList = spendingsService.GetSpendings();
            foreach (Purchase p in purchasesList)
            {
                p.ID.Equals(purchaseEntity.ID);
                p.Name.Equals(purchaseEntity.Name);
                p.Price.Equals(purchaseEntity.Price);
            }
        }
        [Test]
        public void DeleteSpendingTest()
        {
            spendingsService.DeleteSpending(purchaseEntity.ID);
            List<Purchase> purchasesList = spendingsService.GetSpendings();
            purchasesList.Equals(null);
        }
    }
}
