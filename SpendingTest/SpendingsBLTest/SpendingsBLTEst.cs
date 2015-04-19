using System.Collections.Generic;
using System.Data.Entity;
using NSubstitute;
using NUnit.Framework;
using SpendingsBL.Services;
using SpendingsBL.Services.Interfaces;
using SpendingsDAL;

namespace SpendingTest.SpendingsBLTest
{
    [TestFixture]
    public class SpendingsBlTest
    {
		//private PurchaseEntity _purchaseEntity;
		//private ISpendingsService _spendingsService;

		//[SetUp]
		//public void Init()
		//{
		//	_purchaseEntity = new PurchaseEntity
		//	{
		//		Id = 1,
		//		Name = "Bananas",
		//		Price = 1.23m
		//	};

		//	_spendingsService = Substitute.For<SpendingsService>();
		//}

		//[Test]
		//public void SaveSpending()
		//{
		//	//Arrange
		//	//Act
		//	_spendingsService.AddSpending(_purchaseEntity);

		//	//Assert
		//	//_purchasesEntities.Purchases.Received().Add(Arg.Is<Purchase>(p=>p.Name.Equals("Bananas") && p.Price == 1.23m));
		//	//_purchasesEntities.Received().SaveChanges();
		//}

		//[Test]
		//public void GetSpendings()
		//{
		//	//Arrange
		//	//Act
		//	var purchasesList = _spendingsService.GetAllSpendings();

		//	//Assert
		//}

		//[Test]
		//public void DeleteSpendingTest()
		//{
		//	//Arrange
		//	//Act
		//	_spendingsService.DeleteSpending(1);
		//	//Asstert
		//}
    }
}
