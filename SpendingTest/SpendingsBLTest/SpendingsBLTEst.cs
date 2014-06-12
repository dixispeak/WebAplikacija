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
            Name = "Bananas",
            Price = 1.23m
        };

        ISpendingsService spendingsService = new SpendingsService();

        [Test]
        public void GetandAddSpendingsTest()
        {
            spendingsService.AddSpending(purchaseEntity);

            List<Purchase> purchasesListSaved = spendingsService.GetSpendings();
            Purchase purchaseexpected = purchasesListSaved[purchasesListSaved.Count - 1];
            Assert.AreEqual(purchaseexpected.Name, purchaseEntity.Name);
            Assert.AreEqual(purchaseexpected.Price, purchaseEntity.Price);
        }
        [Test]
        public void DeleteSpendingTest()
        {            
            List<Purchase> purchasesList = spendingsService.GetSpendings();
            Purchase purchase = purchasesList[purchasesList.Count - 1];
            spendingsService.DeleteSpending(purchase.PurchaseID);
            purchasesList.Remove(purchase);

            Purchase purchaseexpected = purchasesList[purchasesList.Count - 1];
            List<Purchase> purchasesListSaved = spendingsService.GetSpendings();
            Purchase purchasecurrent = purchasesListSaved[purchasesListSaved.Count - 1];
            Assert.AreEqual(purchaseexpected.Name, purchasecurrent.Name);
            Assert.AreEqual(purchaseexpected.Price, purchasecurrent.Price);
        }
    }
}
