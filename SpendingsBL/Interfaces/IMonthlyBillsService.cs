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
        void AddBill(MonthlyBill purchase);
        void EditBill(MonthlyBill purchase);
        MonthlyBill FindBill(int id);
        bool IsPayedBill(int id, System.DateTime time);
        List<MonthlyBill> GetNotPayedMonthlyBills(DateTime time);
    }
}
