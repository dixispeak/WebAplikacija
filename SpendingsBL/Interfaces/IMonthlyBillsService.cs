using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendingsDAL;

namespace SpendingsBL.Interfaces
{
    public interface IMonthlyBillsService
    {
        List<MonthlyBill> GetMonthlyBills();
        void DeleteBill(int id);
        void AddBill(MonthlyBill bill);
        void EditBill(MonthlyBill bill);
        MonthlyBill FindBill(int id);
        bool IsBillPayed(MonthlyBill bill, DateTime time);
        List<MonthlyBill> GetNotPayedMonthlyBills();
        void AddPayedBillMonth(int id);
    }
}
