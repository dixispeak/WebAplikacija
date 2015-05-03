using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel;
using SpendingsBL.DtoModels;
using SpendingsBL.Services.Interfaces;
using SpendingsDAL.Repositories.EntitiesRepositories;

namespace SpendingsBL.Services
{
	public class MonthlyBillsService : IMonthlyBillsService
	{
		private readonly IMonthlyBillRepository _monthlyBillRepository;

		public MonthlyBillsService()
		{
			_monthlyBillRepository = new MonthlyBillRepository();
		}

		public IEnumerable<MonthlyBillDto> GetAllMonthlyBills()
		{
			var monthlyBillsEntities = _monthlyBillRepository.GetAll();
			return monthlyBillsEntities.Select(MapFromMonthlyBillEntityToDto).ToList();
		}

		public void DeleteBill(int id)
		{
			//Validate
			var billEntity = _monthlyBillRepository.GetById(id);

			if (billEntity == null)
			{
				throw new Exception("Not excisting bill can not be deleted");
			}
			_monthlyBillRepository.Delete(billEntity);
		}

		public void AddBill(MonthlyBillDto billDto)
		{
			var billEntity = MapFromMonthlyBillDtoToEntity(billDto);
			_monthlyBillRepository.Add(billEntity);
		}

		public void UpdateBill(MonthlyBillDto billDto)
		{
			var billEntity = MapFromMonthlyBillDtoToEntity(billDto);
			_monthlyBillRepository.Add(billEntity);
		}

		public MonthlyBillDto GetBillById(int id)
		{
			var billEntity = _monthlyBillRepository.GetById(id);
			var billDto = MapFromMonthlyBillEntityToDto(billEntity);
			return billDto;
		}

		public bool IsBillPayed(MonthlyBillDto bill, DateTime time)
		{
			var isDone = false;

			foreach (var payedBillMonth in bill.PayedBillsMonths)
			{
				if (payedBillMonth.PayedBillMonth == time)
				{
					isDone = true;
				}
			}
			return isDone;
		}

		public IEnumerable<MonthlyBillDto> GetNotPayedMonthlyBills()
		{
			var today = DateTime.Today;
			var notPayedMonthlyBillsDtos = new List<MonthlyBillDto>();
			var monthlyBillsEntities = _monthlyBillRepository.GetAll();

			foreach (var monthlyBillEntity in monthlyBillsEntities)
			{
				var monthlyBillDto = MapFromMonthlyBillEntityToDto(monthlyBillEntity);
				if (monthlyBillEntity.PayedBillsMonths.Any() && !monthlyBillEntity.IsActive)
				{
					if (!IsBillPayed(monthlyBillDto, today))
					{
						notPayedMonthlyBillsDtos.Add(monthlyBillDto);
					}
				}
				else
				{
					notPayedMonthlyBillsDtos.Add(monthlyBillDto);
				}
			}
			return notPayedMonthlyBillsDtos;
		}


		public void AddPayedBillMonth(int id)
		{
			//TODO: Create new Repository need to refactor database
			//var today = DateTime.Today;
			//var monthlyBillEntity = _monthlyBillRepository.GetById(id);
			//var monthlyBillDto = MapFromMonthlyBillEntityToDto(monthlyBillEntity);

			//if (IsBillPayed(monthlyBillDto, today)) return;
			//var payedBillMonthEntity = new PayedBillsMonth
			//{
			//	BillId = id,
			//	PayedBillMonth = today
			//};
			//_monthlyBillRepository.Add(payedBillMonthEntity);
		}

		private MonthlyBill MapFromMonthlyBillDtoToEntity(MonthlyBillDto billDto)
		{
			var billEntity = new MonthlyBill
			{
				BillId = billDto.BillId,
				BillDescription = billDto.BillDescription
			};
			if (billDto.PayedBillsMonths == null)
				return billEntity;
			billEntity.PayedBillsMonths = new List<PayedBillsMonth>();
			foreach (var payedBillMonthDto in billDto.PayedBillsMonths)
			{
				var payedBillMonthEntity = new PayedBillsMonth
				{
					PayedBillsMonthId = payedBillMonthDto.PayedBillMonthId,
					BillId = payedBillMonthDto.BillId,
					PayedBillMonth = payedBillMonthDto.PayedBillMonth
				};
				billEntity.PayedBillsMonths.Add(payedBillMonthEntity);
			}
			return billEntity;
		}

		private MonthlyBillDto MapFromMonthlyBillEntityToDto(MonthlyBill billEntity)
		{
			var billDto = new MonthlyBillDto
			{
				BillId = billEntity.BillId,
				BillDescription = billEntity.BillDescription,
				PayedBillsMonths = new List<PayedBillsMonthDto>()
			};
			if (billDto.PayedBillsMonths == null)
				return billDto;
			foreach (var payedBillsMonthEntity in billEntity.PayedBillsMonths)
			{
				var payedBillsMonthDto = new PayedBillsMonthDto
				{
					BillId = payedBillsMonthEntity.BillId,
					PayedBillMonth = payedBillsMonthEntity.PayedBillMonth,
					PayedBillMonthId = payedBillsMonthEntity.PayedBillsMonthId
				};
				billDto.PayedBillsMonths.Add(payedBillsMonthDto);
			}
			return billDto;
		}
	}
}
