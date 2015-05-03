using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SpendingsBL.DtoModels;
using SpendingsBL.Services.Interfaces;
using WebAplikacija.ViewModels;

namespace WebAplikacija.Controllers
{
	[RequireHttps]
	[Authorize]
	public class PurchasesController : Controller
	{
		private readonly ISpendingsService _spendingsService;
		private readonly IMonthlyBillsService _monthlyBillsService;

		public PurchasesController(ISpendingsService spendingsService, IMonthlyBillsService monthlyBillsService)
		{
			_spendingsService = spendingsService;
			_monthlyBillsService = monthlyBillsService;
		}

		[HttpGet]
		public ActionResult Index()
		{
			var purchasesDtos = _spendingsService.GetAllSpendings();
			var monthlyBillsDtos = _monthlyBillsService.GetNotPayedMonthlyBills();
			if (purchasesDtos == null || monthlyBillsDtos == null)
			{
				return HttpNotFound();
			}

			var purchasesMonthlyBillsView = new PurchasesMonthlyBillsViewModel();
			GetMonthlyBillsAndPurchases(purchasesMonthlyBillsView);

			return View(purchasesMonthlyBillsView);
		}

		[HttpPost]
		public ActionResult Index(PurchasesMonthlyBillsViewModel purchasesMonthlyBillsView)
		{
			var purchaseDtoToSave = MapPurchaseViewModelToDto(purchasesMonthlyBillsView.PurchasesViewModel.Purchase);
			_spendingsService.AddSpending(purchaseDtoToSave);

			GetMonthlyBillsAndPurchases(purchasesMonthlyBillsView);

			return View(purchasesMonthlyBillsView);
		}

		public ActionResult MonthlyBills(string[] billIds, PurchasesMonthlyBillsViewModel purchasesMonthlyBillsView)
		{
			if (billIds == null)
			{
				return HttpNotFound();
			}
			foreach (var id in billIds)
			{
				_monthlyBillsService.AddPayedBillMonth(Convert.ToInt32(id));
			}

			GetMonthlyBillsAndPurchases(purchasesMonthlyBillsView);

			return View("Index", purchasesMonthlyBillsView);
		}

		public ActionResult Delete(int id)
		{
			_spendingsService.DeleteSpending(id);

			var purchasesMonthlyBillsView = new PurchasesMonthlyBillsViewModel();
			GetMonthlyBillsAndPurchases(purchasesMonthlyBillsView);
			return View("Index", purchasesMonthlyBillsView);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Edit(int id)
		{
			var purchaseDto = _spendingsService.GetById(id);
			if (purchaseDto == null)
			{
				return HttpNotFound();
			}
			var purchaseViewModel = MapPurchaseDtoToViewModel(purchaseDto);
			return View(purchaseViewModel);
		}

		[HttpPost]
		public ActionResult Edit(PurchaseViewModel purchaseViewModel)
		{
			var purchaseDto = MapPurchaseViewModelToDto(purchaseViewModel);
			_spendingsService.UpdateSpending(purchaseDto);

			var purchasesMonthlyBillsView = new PurchasesMonthlyBillsViewModel();
			GetMonthlyBillsAndPurchases(purchasesMonthlyBillsView);

			return View("Index", purchasesMonthlyBillsView);
		}

		private void GetMonthlyBillsAndPurchases(PurchasesMonthlyBillsViewModel purchasesMonthlyBillsView)
		{
			var purchasesDtos = _spendingsService.GetAllSpendings();
			var monthlyBillsDtos = _monthlyBillsService.GetNotPayedMonthlyBills();
			if (purchasesDtos == null || monthlyBillsDtos == null)
			{
				return;
			}
			purchasesMonthlyBillsView.PurchasesViewModel = new PurchasesViewModel {PurchasesList = new List<PurchaseViewModel>()};
			foreach (var purchaseViewModel in purchasesDtos.Select(MapPurchaseDtoToViewModel))
			{
				purchasesMonthlyBillsView.PurchasesViewModel.PurchasesList.Add(purchaseViewModel);
			}

			purchasesMonthlyBillsView.MonthlyBillsViewModels = new List<MonthlyBillViewModel>();
			foreach (var monthlyBillsViewModel in monthlyBillsDtos.Select(MapMonthlyBillDtoToViewModel))
			{
				purchasesMonthlyBillsView.MonthlyBillsViewModels.Add(monthlyBillsViewModel);
			}
		}

		private MonthlyBillViewModel MapMonthlyBillDtoToViewModel(MonthlyBillDto monthlyBillDto)
		{
			var monthlyBillViewModel = new MonthlyBillViewModel
			{
				BillId = monthlyBillDto.BillId,
				BillDescription = monthlyBillDto.BillDescription,
				PayedBillsMonths = new List<PayedBillsMonthViewModel>()
			};
			foreach (var payedBillMonthDto in monthlyBillDto.PayedBillsMonths)
			{
				var payedBillMonthViewModel = new PayedBillsMonthViewModel
				{
					BillId = payedBillMonthDto.BillId,
					PayedBillMonth = payedBillMonthDto.PayedBillMonth,
					PayedBillMonthId = payedBillMonthDto.PayedBillMonthId
				};
				monthlyBillViewModel.PayedBillsMonths.Add(payedBillMonthViewModel);
			}
			return monthlyBillViewModel;
		}

		private PurchaseViewModel MapPurchaseDtoToViewModel(PurchaseDto purchaseDto)
		{
			var purchaseViewModel = new PurchaseViewModel
			{
				Name = purchaseDto.Name,
				Price = purchaseDto.Price,
				PurchaseId = purchaseDto.PurchaseId
			};
			return purchaseViewModel;
		}

		private PurchaseDto MapPurchaseViewModelToDto(PurchaseViewModel purchaseViewModel)
		{
			var purchaseDto = new PurchaseDto
			{
				Name = purchaseViewModel.Name,
				Price = purchaseViewModel.Price,
				PurchaseId = purchaseViewModel.PurchaseId
			};
			return purchaseDto;
		}
	}
}