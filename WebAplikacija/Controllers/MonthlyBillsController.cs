using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SpendingsBL.DtoModels;
using SpendingsBL.Services.Interfaces;
using WebAplikacija.ViewModels;

namespace WebAplikacija.Controllers
{
	[Authorize]
	public class MonthlyBillsController : Controller
	{
		private readonly IMonthlyBillsService _monthlyBillsService;

		public MonthlyBillsController(IMonthlyBillsService monthlyBillsService)
		{
			_monthlyBillsService = monthlyBillsService;
		}

		public ActionResult Index()
		{
			var monthlyBillsDtos = _monthlyBillsService.GetAllMonthlyBills();
			if (monthlyBillsDtos == null)
			{
				return HttpNotFound();
			}
			var monthlyBillsViews = monthlyBillsDtos.Select(MapMonthlyBillDtoToViewModel).ToList();

			return View(monthlyBillsViews);
		}

		public ActionResult Details(int id)
		{
			var monthlyBillDto = _monthlyBillsService.GetBillById(id);
			if (monthlyBillDto == null)
			{
				return HttpNotFound();
			}
			var monthlyBillView = MapMonthlyBillDtoToViewModel(monthlyBillDto);
			return View(monthlyBillView);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(MonthlyBillViewModel monthlyBillView)
		{
			if (monthlyBillView == null)
			{
				return View((MonthlyBillViewModel)null);
			}
			var monthlyBillDto = MapMonthlyBillViewModelToDto(monthlyBillView);
			_monthlyBillsService.AddBill(monthlyBillDto);
			return RedirectToAction("Index");
		}

		public ActionResult Edit(int id)
		{
			var monthlyBillDto = _monthlyBillsService.GetBillById(id);
			if (monthlyBillDto == null)
			{
				return HttpNotFound();
			}
			var monthlyBillView = MapMonthlyBillDtoToViewModel(monthlyBillDto);
			return View(monthlyBillView);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(MonthlyBillViewModel monthlyBillView)
		{
			if (monthlyBillView == null)
			{
				return View((MonthlyBillViewModel)null);
			}
			var monthlyBillDto = MapMonthlyBillViewModelToDto(monthlyBillView);
			_monthlyBillsService.UpdateBill(monthlyBillDto);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var monthlyBillDto = _monthlyBillsService.GetBillById(id);
			if (monthlyBillDto == null)
			{
				return HttpNotFound();
			}
			var monthlyBillView = MapMonthlyBillDtoToViewModel(monthlyBillDto);
			return View(monthlyBillView);
		}

		// POST: /MonthlyBills/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_monthlyBillsService.DeleteBill(id);
			return RedirectToAction("Index");
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

		private MonthlyBillDto MapMonthlyBillViewModelToDto(MonthlyBillViewModel monthlyBillView)
		{
			var monthlyBillDto = new MonthlyBillDto
			{
				BillDescription = monthlyBillView.BillDescription
			};
			if (monthlyBillView.PayedBillsMonths == null) return monthlyBillDto;
			monthlyBillDto.PayedBillsMonths = new List<PayedBillsMonthDto>();
			foreach (var payedBillMonthViewModel in monthlyBillView.PayedBillsMonths)
			{
				var payedBillMonthDto = new PayedBillsMonthDto
				{
					PayedBillMonth = payedBillMonthViewModel.PayedBillMonth
				};
				monthlyBillDto.PayedBillsMonths.Add(payedBillMonthDto);
			}
			return monthlyBillDto;
		}
	}
}
