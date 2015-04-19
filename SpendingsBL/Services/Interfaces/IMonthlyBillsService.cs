using System;
using System.Collections.Generic;
using SpendingsBL.DtoModels;

namespace SpendingsBL.Services.Interfaces
{
    public interface IMonthlyBillsService
    {
		IEnumerable<MonthlyBillDto> GetAllMonthlyBills();
        void DeleteBill(int id);
		void AddBill(MonthlyBillDto billsBillDto);
		void UpdateBill(MonthlyBillDto billsBillDto);
		MonthlyBillDto GetBillById(int id);
		bool IsBillPayed(MonthlyBillDto bill, DateTime time);
		IEnumerable<MonthlyBillDto> GetNotPayedMonthlyBills();
        void AddPayedBillMonth(int id);
    }
}
