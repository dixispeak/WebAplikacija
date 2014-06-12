using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendingsBL.Interfaces;
using SpendingsDAL;

namespace SpendingsBL.Services
{
    public class MonthlyBillsService: IMonthlyBillsService
    {
        private MonthlyBillsEntities monthlyBillsContext = new MonthlyBillsEntities();

        public List<MonthlyBill> GetMonthlyBills()
        {
            List<MonthlyBill> MonthlyBillsList = monthlyBillsContext.MonthlyBills.ToList();

            return MonthlyBillsList;
        }

        public void DeleteBill(int id)
        {
            MonthlyBill bill = FindBill(id);

            monthlyBillsContext.MonthlyBills.Remove(bill);

            monthlyBillsContext.SaveChanges();
        }

        public void AddBill(MonthlyBill bill)
        {
            monthlyBillsContext.MonthlyBills.Add(bill);
            monthlyBillsContext.SaveChanges();
        }

        public void EditBill(MonthlyBill bill)
        {
            monthlyBillsContext.Entry(bill).State = EntityState.Modified;
            monthlyBillsContext.SaveChanges();
        }

        public MonthlyBill FindBill(int id)
        {
            MonthlyBill bill = monthlyBillsContext.MonthlyBills.Find(id);
            return bill;
        }
    }
}
