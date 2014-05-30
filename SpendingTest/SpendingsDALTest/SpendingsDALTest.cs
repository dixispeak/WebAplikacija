using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendingsDAL;
using SpendingsBL.Entities;


namespace SpendingTest.SpendingsDALTest
{
    [TestFixture]
    public class SpendingsDALTest
    {
        private PurchaseEntities purchasesContext;
        private List<Purchase> puchasesTable;

        [Test]
        public void AddPurchasesTest () 
        {
            purchasesContext = new PurchaseEntities();
            puchasesTable = purchasesContext.Purchases

            public DBset
        }
    }
}
